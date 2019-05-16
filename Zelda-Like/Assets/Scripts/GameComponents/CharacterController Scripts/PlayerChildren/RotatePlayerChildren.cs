using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerChildren : MonoBehaviour
{
    public class RotateController : MonoBehaviour
    {
        public Transform FiringAxis;

        private float hright;
        private float vright;

        [Range(0, 0.62f), SerializeField]
        private float joystickTolerance = 0f;

        private void Update()
        {
            PlayerRotate(FiringAxis, hright, vright);
        }

        void PlayerRotate(Transform player, float hright, float vright)
        {
            hright = Input.GetAxis("Horizontal");
            vright = Input.GetAxis("Vertical");

            if (hright > joystickTolerance || hright < -joystickTolerance || vright > joystickTolerance || vright < -joystickTolerance)
                player.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(hright, vright) * 180 / Mathf.PI);
        }
    }
}
