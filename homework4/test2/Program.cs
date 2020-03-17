using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{

        public delegate void ClockHandler(object sender, DateTime dataTime);

        public class AlarmClock
        {
            public event ClockHandler Tick;
            public event ClockHandler Alarm;
            private DateTime alarmTime;
            public DateTime AlarmTime
            {
                get => alarmTime;
                set => alarmTime = value;
            }
            public void Run()
            {
                Console.WriteLine("开始运行！");
                while (true)
                {
                    Tick(this, DateTime.Now);
                    if (DateTime.Now.ToString() == AlarmTime.ToString())
                    {
                        Alarm(this, DateTime.Now);
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }

        }

    public class MyClock
    {
        public AlarmClock alarmClock = new AlarmClock();
        public MyClock()
        {
           // alarmClock = new AlarmClock();
            DateTime alarmTime = new DateTime();
            int year, month, day, hour, minute, second;
            Console.WriteLine("Please enter the accurate alarm time of your clock");
            Console.WriteLine("NOTICE:");
            Console.WriteLine("1. Enter year, month, day, hour ,minute and second IN TURN");
            Console.WriteLine("2. Seperate them with the ENTER key");
            Console.WriteLine("3. If you don't need to set the second, please set it as 0");
            try
            {
                year = int.Parse(Console.ReadLine());
                month = int.Parse(Console.ReadLine());
                day = int.Parse(Console.ReadLine());
                hour = int.Parse(Console.ReadLine());
                minute = int.Parse(Console.ReadLine());
                second = int.Parse(Console.ReadLine());
                alarmTime = new DateTime(year, month, day, hour, minute, second);
                Console.WriteLine($"You have set the alarm time as {alarmTime}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error:the time you enter is out of range");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error:the format of time you enter is wrong");
            }
            // alarmClock.AlarmTime = new DateTime(2020, 3, 17, 16, 26, 0);
            alarmClock.AlarmTime = alarmTime;
            alarmClock.Tick += new ClockHandler(Alarm_tick);
            alarmClock.Alarm += Alarm_alarm;
        }
        void Alarm_tick(object sender, DateTime dateTime)
        {
            Console.WriteLine($"滴答......滴答......  现在时间：{dateTime.ToString()}");
        }
        void Alarm_alarm(object sender, DateTime dateTime)
        {
            Console.WriteLine($"叮铃铃......叮铃铃......  现在时间：{dateTime.ToString()}");
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClock myClock = new MyClock();
            myClock.alarmClock.Run();
        }
    }

}
