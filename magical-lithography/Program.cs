using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace magicallithography
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            asd.Engine.Initialize("magical-lithography",1080,800,new asd.EngineOption());
            TitleScene title = new TitleScene();
            asd.Engine.ChangeSceneWithTransition(title, new asd.TransitionFade(1.0f, 1.0f));
            while (asd.Engine.DoEvents())
            {
                asd.Engine.Update();
            }
        }
    }
}
