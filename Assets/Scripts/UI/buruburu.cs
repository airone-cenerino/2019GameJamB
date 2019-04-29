using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal enum VibrateType
{
    VERTICAL,
    HORIZONTAL
}
public class buruburu : MonoBehaviour
{
    [SerializeField] private VibrateType vibrateType;
    [Range(0, 100)] [SerializeField] private float vibrateRange;
    [SerializeField] private float vibrateSpeed;

    private float initPosition;
    private float newPosition;
    private float minPosition;
    private float maxPosition;
    private bool directionToggle;

    //Use this for initialization 
    void Start(){
        switch (this.vibrateType)
        {
            case VibrateType.VERTICAL:
                this.initPosition = transform.localPosition.x;
                break;
        }

        this.newPosition = this.initPosition;
        this.minPosition = this.initPosition - this.vibrateRange;
        this.maxPosition = this.initPosition + this.vibrateRange;
        this.directionToggle = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vibrate();
    }

    private void Vibrate()
    {
        if (this.newPosition <= this.minPosition ||
                                                    this.maxPosition <= this.newPosition)
        {
            this.directionToggle = !this.directionToggle;
        }
        this.newPosition = this.directionToggle ?
                                                    this.newPosition + (vibrateSpeed * Time.deltaTime) :
                                                    this.newPosition - (vibrateSpeed * Time.deltaTime);
        this.newPosition = Mathf.Clamp
(this.newPosition, this.minPosition, this.maxPosition);

        switch(this.vibrateType)
        {
            case VibrateType.VERTICAL:

                this.transform.localPosition = new Vector3(0, this.newPosition, 0);
                break;
            case
                VibrateType.HORIZONTAL:

                this.transform.localPosition = new Vector3(this.newPosition, 0, 0);
                break;
        }
    }
}
