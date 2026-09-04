using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class InputTranslator : MonoBehaviour
{
    [SerializeField] private bool _holdingW;

    [SerializeField] private UnityEvent _WKeyHold;

    private int _inputTime;

    private KeyCode _WKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _holdingW = false;

        _inputTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (_inputTime = 5; _inputTime > 0; _inputTime--)
            {

            _holdingW = true;
            
             HoldingWKey();

            if(_inputTime == 0)
            {
                _holdingW = false;       
            }
        }
    }
    }

    private void HoldingWKey()
    {
        _WKeyHold?.Invoke();
    }
}
