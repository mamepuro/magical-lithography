using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace magicallithography
{
    public class GameScene:asd.Scene
    {
        public GameScene()
        {}
        protected override void OnRegistered()
        {
            asd.Layer2D layer = new asd.Layer2D();
            AddLayer(layer);
            Player player = new Player();
            layer.AddObject(player);
            base.OnRegistered();
        }
        protected override void OnUpdated()
        {
            base.OnUpdated();
        }

    }
}
