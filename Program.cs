using System;
using System.Device.Gpio;
using System.Threading;

using projetIoT;

namespace projetIoT
{
    class Program
    {
        static void Main(string[] args)
        {
            int pin = 4;
            int pinBtn=17;
            int pinbell=27;
            using var controller = new GpioController();
            using var btnController= new GpioController();
            using var bellController=new GpioController();
            var httpConnector=new HttpConnector();


            btnController.OpenPin(pinBtn,PinMode.Input);
            controller.OpenPin(pin, PinMode.Output);
            bellController.OpenPin(pinbell,PinMode.Output);
            bool ledOn = false;
            PinValue btnValue=PinValue.Low;
            controller.Write(pin,btnValue);
            while (true)
            {
                PinValue rd=btnController.Read(pinBtn);
                if(btnValue!=rd){
                    btnValue=rd;
                    controller.Write(pin,btnValue==PinValue.High?PinValue.Low:PinValue.High);
                    ledOn= btnValue==PinValue.Low;
                    httpConnector.ring(ledOn);
                }

              
            }
        }
    }
}
