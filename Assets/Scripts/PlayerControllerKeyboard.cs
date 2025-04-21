using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerKeyboard : MonoBehaviour
{
    [Header("Jugador")]
    [Tooltip("1 = WASD, 2 = Flechas")]
    [SerializeField] private int playerId = 1;

    [Header("Sensibilidad (grados/s)")]
    [SerializeField] private float yawSensitivity   = 180f;
    [SerializeField] private float pitchSensitivity = 180f;

    [Header("Suavizado de rotación")]
    [Tooltip("Cuánto tarda en alcanzar la rotación objetivo")]
    [SerializeField] private float smoothing = 10f;

    [Header("Límites de inclinación vertical")]
    [SerializeField] private float minPitch = -45f;
    [SerializeField] private float maxPitch =  45f;

    private InputAction lookAction;
    private float targetYaw;
    private float targetPitch;

    private void Awake()
    {
        // Inicializa los ángulos desde la rotación actual
        Vector3 e = transform.localEulerAngles;
        targetYaw   = e.y;
        targetPitch = e.x;

        // Configura composite WASD o Flechas
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

    private void OnEnable()  => lookAction.Enable();
    private void OnDisable() => lookAction.Disable();

    private void Update()
    {
        Vector2 v = lookAction.ReadValue<Vector2>();

        // Yaw (izquierda/derecha)
        if (Mathf.Abs(v.x) > 0.01f)
            targetYaw += v.x * yawSensitivity * Time.deltaTime;

        // Pitch (arriba/abajo), invertido para W/↑ = mirar arriba
        if (Mathf.Abs(v.y) > 0.01f)
        {
            targetPitch -= v.y * pitchSensitivity * Time.deltaTime;
            targetPitch = Mathf.Clamp(targetPitch, minPitch, maxPitch);
        }

        // Rotación suave hacia el objetivo
        Quaternion goal = Quaternion.Euler(targetPitch, targetYaw, 0f);
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            goal,
            smoothing * Time.deltaTime
        );
    }
}
