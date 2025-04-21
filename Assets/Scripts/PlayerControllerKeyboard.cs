using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerKeyboard : MonoBehaviour
{
    [Header("Jugador")]
    [SerializeField, Tooltip("1 = WASD, 2 = Flechas")]
    private int playerId = 1;

    [Header("Velocidad de rotación (grados/s)")]
    [SerializeField] private float yawSpeed   = 90f;
    [SerializeField] private float pitchSpeed = 90f;

    [Header("Límites de inclinación vertical")]
    [SerializeField] private float minPitch = -45f;
    [SerializeField] private float maxPitch =  45f;

    private InputAction lookAction;
    private float currentYaw;
    private float currentPitch;

    private void Awake()
    {
        // Arrancamos con la rotación inicial
        Vector3 e = transform.localEulerAngles;
        currentYaw   = e.y;
        currentPitch = e.x;

        // Configuro WASD o flechas
        lookAction = new InputAction($"Look_P{playerId}", InputActionType.Value);
        var cb = lookAction.AddCompositeBinding("2DVector");
        if (playerId == 1)
        {
            cb.With("Up",    "<Keyboard>/w")
              .With("Down",  "<Keyboard>/s")
              .With("Left",  "<Keyboard>/a")
              .With("Right", "<Keyboard>/d");
        }
        else
        {
            cb.With("Up",    "<Keyboard>/upArrow")
              .With("Down",  "<Keyboard>/downArrow")
              .With("Left",  "<Keyboard>/leftArrow")
              .With("Right", "<Keyboard>/rightArrow");
        }
    }

    private void OnEnable()
    {
        lookAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }

    private void Update()
    {
        Vector2 v = lookAction.ReadValue<Vector2>();

        // Yaw (izquierda/derecha)
        if (Mathf.Abs(v.x) > 0.01f)
            currentYaw += v.x * yawSpeed * Time.deltaTime;

        // Pitch (arriba/abajo)
        if (Mathf.Abs(v.y) > 0.01f)
        {
            currentPitch += v.y * pitchSpeed * Time.deltaTime;
            currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);
        }

        // Aplico rotación local a la cámara
        transform.localRotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
    }
}
