using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAQPemex
{
    class DAQBoardInterface
    {
        private MccDaq.MccBoard board;
        private MccDaq.Range range;
        private MccDaq.ErrorInfo errorLog;
        private int chan;


        public DAQBoardInterface():this(0,0)
        {            
            
        }

        public DAQBoardInterface(int boardNumber, int channel)
        {
            board = new MccDaq.MccBoard(boardNumber);
            range = MccDaq.Range.Bip10Volts;
            chan = channel; 
        }

        public void setChan(int n)
        {
            chan = n;
        }
        public int getChan()
        {
            return chan;
        }
        public void setRange(MccDaq.Range _range)
        {
            range = _range;
        }
        public MccDaq.Range getRange()
        {
            return range;
        }

        public float boardData()
        {
            ushort tempData;
            float convertedData;

            errorLog  = board.AIn(chan, range, out tempData);
            if (errorLog.Value != MccDaq.ErrorInfo.ErrorCode.NoErrors)
            {
                throw new ArgumentException("Error: " + errorLog.Value.ToString());
            }

            convertedData = convertToVolts(tempData);
            return convertedData;

        }

        public float boardDataV()
        {
            float tempData;
            MccDaq.VInOptions options = MccDaq.VInOptions.Default;


            errorLog = board.VIn(chan, range, out tempData, options);
            if (errorLog.Value != MccDaq.ErrorInfo.ErrorCode.NoErrors)
            {
                throw new ArgumentException("Error: " + errorLog.Value.ToString());
            }
            return tempData;

            
           
        }

        private float convertToVolts(ushort datos)
        {
            float temp;
            errorLog = board.ToEngUnits(range, datos, out temp);
            if (errorLog.Value != MccDaq.ErrorInfo.ErrorCode.NoErrors)
            {
                throw new ArgumentException("Error: " + errorLog.Value.ToString());
            }
            return temp;
        }
    }
}
