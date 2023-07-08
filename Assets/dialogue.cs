using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private Dictionary<string, string[,]> DialogueLibrary = new Dictionary<string, string[,]>();
    
    void Start() {
        DialogueLibrary["Introduction"] = new string[,] {
            {"Person 1: Did you know that there's a tunnel under Ocean Boulevard?\nMosaic ceilings, painted tiles on the wall"  +
            "\nI can't help but feel somewhat like my body marred my soul\nHandmade beauty sealed up by two man-made walls", "1"},
            {"Person 2: And I'm like\nWhen's it gonna be my turn?\nWhen's it gonna be my turn?", "2"},
            {"Person 1: Open me up, tell me you like it", "1"}
        };

        DialogueLibrary["Interrogation"] = new string[,] {
            {"Person 1: Your head in your hands\nAs you color me blue", "1"},
            {"Person 1: Blue, blue, blue", "1"},
            {"Person 2: You act like a kid even though you stand six foot two", "2"}
        };
    }

    public Dictionary<string, string[,]> GetDialogueLibrary() {
        return DialogueLibrary;
    }
}
