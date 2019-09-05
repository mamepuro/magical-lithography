using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace magicallithography
{
    public class Player:asd.TextureObject2D
    { 
        const float gravity = 0.98f;
        bool isFlying = false;
        bool isLanding = true;
        int jumpcount;
        const float jumpfirstvelocity = -100.0f;
        float jumpvelocity;
        //private float jumppos = 0.0f;
        public Player()//constructor
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/player.png");
            Position = new asd.Vector2DF(60, 100); 
        }
        //更新時に実行されるメソッド
        protected override void OnUpdate()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
            {
                this.Position += new asd.Vector2DF(3.0f, 0.0f);
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
            {
                this.Position += new asd.Vector2DF(-3.0f, 0.0f);
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push)
            {
                isFlying = true;
                isLanding = false;
                jumpcount = 30;
                jumpvelocity = jumpfirstvelocity;
            }
            if(isFlying == true)
            {
                if (jumpvelocity < 0)
                {
                    this.Position += new asd.Vector2DF(0.0f, jumpvelocity);
                    jumpvelocity += 20.0f;
                }
                else
                {
                    jumpvelocity += 20.0f;
                    this.Position += new asd.Vector2DF(0.0f, jumpvelocity);
                    if(jumpvelocity >= 100.0f)
                    {
                        isFlying = false;
                    }
                }
            }

            
            //画面内に収まるようにする
            asd.Vector2DF position = this.Position;
            position.X = asd.MathHelper.Clamp(position.X, asd.Engine.WindowSize.X - Texture.Size.X , 0.0f);//asd.MathHelper.Clamp(制御したい変数,最大値,最小値)
            position.Y = asd.MathHelper.Clamp(position.Y, asd.Engine.WindowSize.Y - Texture.Size.Y , 500 - Texture.Size.Y);
            this.Position = position;
            base.OnUpdate();
        }
    }
}
