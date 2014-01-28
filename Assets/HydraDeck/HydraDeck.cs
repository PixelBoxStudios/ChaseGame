/*  HydraDeck camera code by Teddy0@gmail.com
  
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using UnityEngine;

//This is a dummy class, for passing values from C# to JS in the simplest way possible

public class HydraDeck : MonoBehaviour
{
    public bool bEnabled = false;

    public bool bTrigger = false;
    public bool bBumper = false;
    public bool bButton1 = false;
    public bool bButton2 = false;
    public bool bButton3 = false;
    public bool bButton4 = false;
    public bool bStart = false;
    public bool bJoyButton = false;

    public bool bTriggerPressed = false;
    public bool bBumperPressed = false;
    public bool bButton1Pressed = false;
    public bool bButton2Pressed = false;
    public bool bButton3Pressed = false;
    public bool bButton4Pressed = false; 
    public bool bStartPressed = false;
    public bool bJoyButtonPressed = false;

    public bool bTriggerReleased = false;
    public bool bBumperReleased = false;
    public bool bButton1Released = false;
    public bool bButton2Released = false;
    public bool bButton3Released = false;
    public bool bButton4Released = false;
    public bool bStartReleased = false;
    public bool bJoyButtonReleased = false;

    public Quaternion BodyRotation = new Quaternion(0,0,1,0);

    public Vector3 BodyPosition = new Vector3(0, 0, 0);
    public Vector3 GunPosition = new Vector3(0,0,0);
    public Quaternion GunRotation = new Quaternion(0,0,1,0);

    public Vector3 CurrentLeftOffset = new Vector3(0, 0, 0);

    public float JoystickX = 0;
    public float JoystickY = 0;

    public RenderTexture HelpTextTexture = null;
    public GameObject HelpTextObject = null;

    //This is the orientation of the left hydra unit (when it's attached to the chest)
    public Quaternion LeftRotationOffset;
    //This is the vector from the left hydra unit to the base of the player's neck
    public Vector3 ChestToNeckOffset;
    //This is the distance (in Hydra units) from the Hydra Base to the Floor
    public float HydraFloorY;
    public enum CameraState
    {
        Disabled,
        CalibrateFloor,
        CalibrateChest,
        CalibrateNeck,
        Enabled
    };
    public CameraState State = CameraState.Disabled;

    // Update is called once per frame
    void Update()
    {
    }
};