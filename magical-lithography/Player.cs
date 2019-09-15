using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace magicallithography
{
    public class Player:asd.TextureObject2D
    {
        //const float gravity = 12.0f;
        //float time =1.0f;
        //float movedeistance1;
        //float movedeistance2 = 0.0f;
        bool isFlying = false;//ジャンプ中かのフラグ
        //bool isLanding = true;
        float jumpcount = 1.0f;
        const float jumpfirstvelocity = -100.0f;//ジャンプの初速
        float jumpvelocity1;//移動距離
        float jumpvelocity2 = 0.0f;

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
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push )
            {
                isFlying = true;
                //isLanding = false;
                //jumpcount = 30;
                //jumpvelocity = jumpfirstvelocity;
            }
            if (isFlying && asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
            {
                jumpvelocity1 = 5.0f * (jumpcount - 10.0f) * (jumpcount - 10.0f) - 500.0f;
                Position += new asd.Vector2DF(0.0f, (jumpvelocity1 - jumpvelocity2) * -1.0f);
                jumpcount += 0.1f;
                jumpvelocity2 = jumpvelocity1;
                if(jumpcount != 0.0f && jumpvelocity2 == 0)
                {
                    jumpcount = 1.0f;
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
