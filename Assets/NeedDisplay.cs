using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedDisplay : MonoBehaviour
{
    public Need need;

    // Used for periodically sampling change in need's value and displaying # of decreasing/increasing arrows.
    [SerializeField]
    float sampleInterval;
    float valueDelta;
    float prevValue;
    float prevSampleTime;

    [SerializeField]
    Slider bar;
    [SerializeField]
    Text nameText;
    [SerializeField]
    Image arrowsLeftImage;
    [SerializeField]
    Image arrowsRightImage;

    // These sprites are displayed before the start of the bar if the value is decreasing.
    [SerializeField]
    Sprite oneArrowLeftSprite;
    [SerializeField]
    Sprite twoArrowsLeftSprite;
    [SerializeField]
    Sprite threeArrowsLeftSprite;

    // These sprites are displayed after the end of the bar if the value is increasing.
    [SerializeField]
    Sprite oneArrowRightSprite;
    [SerializeField]
    Sprite twoArrowsRightSprite;
    [SerializeField]
    Sprite threeArrowsRightSprite;

    private void OnEnable()
    {
        this.nameText.text = need.Label;

        this.prevValue = this.need.Value;
        this.valueDelta = 0;
        this.prevSampleTime = Time.time;

        this.arrowsLeftImage.sprite = null;
        this.arrowsRightImage.sprite = null;
    }

    private void Update()
    {
        bar.value = need.Value;

        if (Time.time - this.prevSampleTime > this.sampleInterval)
        {
            this.valueDelta = this.need.Value - this.prevValue;
            this.prevSampleTime = Time.time;
            this.prevValue = this.need.Value;
            this.UpdateValueChangeSprites();
        }
    }

    private void UpdateValueChangeSprites()
    {
        this.arrowsLeftImage.sprite = null;
        this.arrowsRightImage.sprite = null;

        float changePerSecond = this.valueDelta / (this.sampleInterval / 1);
        float sign = Mathf.Sign(this.valueDelta);

        if (changePerSecond == 0) return;

        float minutesForRate0To1 = Mathf.Abs(1 / (changePerSecond * 60)); // 1 is the max need value

        if (minutesForRate0To1 < 5.1f)
        {
            if (sign > 0) this.arrowsRightImage.sprite = this.threeArrowsRightSprite;
            else this.arrowsLeftImage.sprite = this.threeArrowsLeftSprite;
        }
        else if (minutesForRate0To1 < 10.1f)
        {
            if (sign > 0) this.arrowsRightImage.sprite = this.twoArrowsRightSprite;
            else this.arrowsLeftImage.sprite = this.twoArrowsLeftSprite;
        }
        else
        {
            if (sign > 0) this.arrowsRightImage.sprite = this.oneArrowRightSprite;
            else this.arrowsLeftImage.sprite = this.oneArrowLeftSprite;
        }

    }
}
