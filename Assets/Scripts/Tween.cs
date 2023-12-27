using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Tween : MonoBehaviour
{
    [Header("Cube Jump")]
    [SerializeField] private GameObject cube;
    [SerializeField] private Button moveCubeButton;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float sizeScale = 5f;
    [SerializeField] private float rotationDegree = 360;
    [SerializeField] private float duration;
    [SerializeField] private Ease jumpEase = Ease.OutQuint;
    [FormerlySerializedAs("scaleEase")] [SerializeField] private Ease rotateEase = Ease.InOutCubic;
    
    [Header("UI Tween")]
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private Button uiTweenButton;
    [SerializeField] private Color endColor;
    [SerializeField] private Color startColor;

    private bool isCubeBig = false;
    private int cubeTweenId = 0;
    private List<int> jumpTweens = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        moveCubeButton.onClick.AddListener(TweenUI);
    }

    private void MoveCube()
    {
        if (cubeTweenId != 0) DOTween.Kill(cubeTweenId);
        cube.transform.localScale = Vector3.one;
        cubeTweenId = cube.transform.DOScale(2f, 1f).intId;
    }

    private void FlipScaleCube()
    {
        if (isCubeBig)
        {
            cube.transform.DOScale(1f, 1f);
            isCubeBig = false;
        }
        else
        {
            cube.transform.DOScale(2f, 1f);
            isCubeBig = true;
        }

        /*float target = isCubeBig ? 1f : 2f;
        cube.transform.DOScale(target, 1f);
        isCubeBig = !isCubeBig;*/
    }

    private void CubeJump()
    {
        foreach (var tween in jumpTweens)
        {
            DOTween.Kill(tween);
        }
        
        jumpTweens.Clear();
        
        cube.transform.localPosition = Vector3.zero;
        var jump= cube.transform.DOMoveY(jumpHeight, duration).SetEase(jumpEase).intId;
        cube.transform.localRotation = Quaternion.identity;
        var rotate = cube.transform.DORotate(new Vector3(0, rotationDegree, 0), duration, RotateMode.LocalAxisAdd).SetEase(rotateEase).intId;
        cube.transform.localScale = Vector3.one;
        var scale =cube.transform.DOScale(sizeScale, duration).intId;
        
        jumpTweens.Add(jump);
        jumpTweens.Add(rotate);
        jumpTweens.Add(scale);
    }

    private void TweenUI()
    {
        image.color = startColor;
        image.DOColor(endColor, duration);
        textMeshProUGUI.color = new Color(0, 0, 0, 0);
        textMeshProUGUI.DOFade(1, duration);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
