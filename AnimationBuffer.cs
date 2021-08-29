using System;
using System.Collections.Generic;
using System.Text;

namespace Mythkeeper {
    class AnimationBuffer {

        private List<AnimatedSprite> spriteBuffer;

        public AnimationBuffer() {

            spriteBuffer = new List<AnimatedSprite>();

        }

        public void QueueAnim(AnimatedSprite sprite) {

            spriteBuffer.Add(sprite);
        }

        public AnimatedSprite DequeueAnim(int index) {

            AnimatedSprite sprite = spriteBuffer[index];

            for (int i = index; i < spriteBuffer.Count - 1; i++) {

                spriteBuffer[i] = spriteBuffer[i + 1];

            }

            spriteBuffer.RemoveAt(spriteBuffer.Count - 1);

            return sprite;

        }

        public void ClearBuffer() {

            spriteBuffer.Clear();

        }

        public Boolean IsEmpty() {

            return (spriteBuffer.Count == 0) ? true : false;

        }
    }
}
