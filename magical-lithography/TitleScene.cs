using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace magicallithography
{
    public class TitleScene:asd.Scene
    {
        public TitleScene()//constructor
        {}
        protected override void OnRegistered()
        {
            asd.Layer2D layer = new asd.Layer2D();
            AddLayer(layer);
            asd.TextureObject2D background = new asd.TextureObject2D();
            background.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/Title.png");
            layer.AddObject(background);
            base.OnRegistered();
        }
        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                asd.Engine.ChangeSceneWithTransition(new GameScene(), new asd.TransitionFade(1.0f, 1.0f));
            }
            base.OnUpdated();
        }
    }
}
