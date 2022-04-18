using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Core.Managers
{

    public class Message_Que_Manager : ACT.Core.Interfaces.Managers.I_MessageQueManager
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="CustomProcessor">Custom Message Processor</param>
        public Message_Que_Manager(Func<string, bool, string> CustomProcessor)
        {
            if (CustomProcessor != null)
            {
                _IfUseExternalFunc = true;
                ExternalProcessor = CustomProcessor;
            }
            else
            {
                _IfUseExternalFunc = false;
            }
        }

        #region Private Variables
        
        private string _JSON_Encoding_Type = "Message_Que_Json";
        private ulong _TotalProcessedSinceStart = 0;
        private DateTime _DatesStarted = DateTime.Now;
        private bool _IsRunning = false;
        private bool _IfUseExternalFunc = false;
        private int _ImportanceExecuteNowMin = 100;
        private Func<string, bool, string> _ExternalProcessor = null;
        
        #endregion

        #region Messages
        
        public ArrayList HighImportanceMessages => new ArrayList();
        public ArrayList Messages => new ArrayList();
        
        #endregion

        #region public Properties
        
        public string Json_Encoding_Type { get { return _JSON_Encoding_Type; } set { _JSON_Encoding_Type = value; } }
        public decimal MovingProcessingAverage { get { return Convert.ToDecimal((DateTime.Now - _DatesStarted).TotalMinutes / _TotalProcessedSinceStart); } }
        public int ImportanceExecuteNowMin { get { return _ImportanceExecuteNowMin; } set { _ImportanceExecuteNowMin = value; } }
        
        #endregion

        #region Methods
        
        public void Pause() { _IsRunning = false; }
        public void Start() { _IsRunning = true; }
        public void Stop() { _IsRunning = false; }
        public (string,bool) POP()
        {
            var _MessageToProcess = "";
            bool _HighImp = false;

            lock (Messages) lock (HighImportanceMessages)
                {
                    if (HighImportanceMessages.Count > 0)
                    {
                        _MessageToProcess = HighImportanceMessages[0].ToString();
                        HighImportanceMessages.RemoveAt(0);
                        _HighImp = true;
                    }
                    else
                    {
                        if (Messages.Count > 0)
                        {
                            _MessageToProcess = Messages[0].ToString();
                            Messages.RemoveAt(0);
                        }
                        else
                        {
                            return (null,false);
                        }
                    }
                }

            return (_MessageToProcess, _HighImp);
        }
        public string PUSH(string message, int Importance)
        {
            lock (Messages) lock (HighImportanceMessages)
                {
                    if (Importance > _ImportanceExecuteNowMin)
                    {
                        HighImportanceMessages.Add(message);
                        return "HIGH";
                    }
                    else
                    {
                        Messages.Add(message);
                        return "NORMAL";
                    }
                }
        }
        public string PUSHTOBOTTOM(string message, int Importance)
        {
            lock (Messages) lock (HighImportanceMessages)
                {
                    if (Importance > _ImportanceExecuteNowMin)
                    {
                        HighImportanceMessages.Add(message);
                        return "HIGH";
                    }
                    else
                    {
                        Messages.Add(message);
                        return "NORMAL";
                    }
                }
        }
        public string PUSHTOTOP(string message, int Importance)
        {
            lock (Messages) lock (HighImportanceMessages)
                {
                    if (Importance > _ImportanceExecuteNowMin)
                    {
                        HighImportanceMessages.Insert(0, message);
                        return "HIGH";
                    }
                    else
                    {
                        Messages.Insert(0, message);
                        return "NORMAL";
                    }
                }
        }
        
        #endregion

        /// <summary>
        /// Process
        /// </summary>
        /// <returns></returns>
        public string Process()
        {
            var _Message = POP();

            if (_ExternalProcessor != null)
            {
                string _tmpReturn = _ExternalProcessor(_Message.Item1, _Message.Item2);
                if (_ExternalProcessor == null)
                {
                    //LOG ERROR
                    return null;
                }
                else
                {
                    return _tmpReturn;
                }
            }
            else
            {
                //TODO
                return null;
            }
        }
    }
}
