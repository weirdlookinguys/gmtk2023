using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private Dictionary<string, string[]> DialogueLibrary = new Dictionary<string, string[]>();
    
    void Start() {
        DialogueLibrary["Introduction"] = new string[] {
            "Did you know that there's a tunnel under Ocean Boulevard?\nMosaic ceilings, painted tiles on the wall" +
            "\nI can't help but feel somewhat like my body marred my soul\nHandmade beauty sealed up by two man-made walls",
            "And I'm like\nWhen's it gonna be my turn?\nWhen's it gonna be my turn?",
            "Open me up, tell me you like it"
        };

        DialogueLibrary["Interrogation"] = new string[] {
            "Your head in your hands\nAs you color me blue",
            "Blue, blue, blue",
            "You act like a kid even though you stand six foot two"
        };
    }

    public Dictionary<string, string[]> GetDialogueLibrary() {
        return DialogueLibrary;
    }
}
