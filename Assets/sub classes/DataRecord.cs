using UnityEngine;

/// <summary>
/// This class is responsible for storing the data associated with each game object
/// </summary>
public class DataRecord : MonoBehaviour
{
    private Transform _transform;
    private string _name;
    private int _layer;
    private string _tag;
    private bool _activeSelf;
    private bool _activeInHierarchy;
    private Component[] _components;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private MeshRenderer _meshRenderer;
    private AudioSource _audioSource;
    private Animator _animator;

    /// <summary>
    /// This method gets the transform item.
    /// </summary>
    /// <returns>The stored transform.</returns>
    public Transform GetTransform()
    {
        return _transform;
    }

    /// <summary>
    /// This method sets the transform variable.
    /// </summary>
    /// <param name="transform">The transform to set.</param>
    public void SetTransform(Transform transform)
    {
        _transform = transform;
    }

    /// <summary>
    /// This method gets the name of the game object.
    /// </summary>
    /// <returns>The stored name.</returns>
    public string GetName()
    {
        return _name;
    }

    /// <summary>
    /// This method sets the name of the game object.
    /// </summary>
    /// <param name="name">The name to set.</param>
    public void SetName(string name)
    {
        _name = name;
    }

    /// <summary>
    /// This method gets the layer of the game object.
    /// </summary>
    /// <returns>The stored layer.</returns>
    public int GetLayer()
    {
        return _layer;
    }

    /// <summary>
    /// This method sets the layer of the game object.
    /// </summary>
    /// <param name="layer">The layer to set.</param>
    public void SetLayer(int layer)
    {
        _layer = layer;
    }

    /// <summary>
    /// This method gets the tag of the game object.
    /// </summary>
    /// <returns>The stored tag.</returns>
    public string GetTag()
    {
        return _tag;
    }

    /// <summary>
    /// This method sets the tag of the game object.
    /// </summary>
    /// <param name="tag">The tag to set.</param>
    public void SetTag(string tag)
    {
        _tag = tag;
    }

    /// <summary>
    /// This method gets the activeSelf state of the game object.
    /// </summary>
    /// <returns>The stored activeSelf state.</returns>
    public bool GetActiveSelf()
    {
        return _activeSelf;
    }

    /// <summary>
    /// This method sets the activeSelf state of the game object.
    /// </summary>
    /// <param name="activeSelf">The activeSelf state to set.</param>
    public void SetActiveSelf(bool activeSelf)
    {
        _activeSelf = activeSelf;
    }

    /// <summary>
    /// This method gets the activeInHierarchy state of the game object.
    /// </summary>
    /// <returns>The stored activeInHierarchy state.</returns>
    public bool GetActiveInHierarchy()
    {
        return _activeInHierarchy;
    }

    /// <summary>
    /// This method sets the activeInHierarchy state of the game object.
    /// </summary>
    /// <param name="activeInHierarchy">The activeInHierarchy state to set.</param>
    public void SetActiveInHierarchy(bool activeInHierarchy)
    {
        _activeInHierarchy = activeInHierarchy;
    }

    /// <summary>
    /// This method gets the array of components associated with the game object.
    /// </summary>
    /// <returns>The stored array of components.</returns>
    public Component[] GetComponents()
    {
        return _components;
    }

    /// <summary>
    /// This method sets the array of components associated with the game object.
    /// </summary>
    /// <param name="components">The array of components to set.</param>
    public void SetComponents(Component[] components)
    {
        _components = components;
    }

    /// <summary>
    /// This method gets the Rigidbody component associated with the game object.
    /// </summary>
    /// <returns>The stored Rigidbody component.</returns>
    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    /// <summary>
    /// This method sets the Rigidbody component associated with the game object.
    /// </summary>
    /// <param name="rigidbody">The Rigidbody component to set.</param>
    public void SetRigidbody(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    /// <summary>
    /// This method gets the Collider component associated with the game object.
    /// </summary>
    /// <returns>The stored Collider component.</returns>
    public Collider GetCollider()
    {
        return _collider;
    }

    /// <summary>
    /// This method sets the Collider component associated with the game object.
    /// </summary>
    /// <param name="collider">The Collider component to set.</param>
    public void SetCollider(Collider collider)
    {
        _collider = collider;
    }

    /// <summary>
    /// This method gets the MeshRenderer component associated with the game object.
    /// </summary>
    /// <returns>The stored MeshRenderer component.</returns>
    public MeshRenderer GetMeshRenderer()
    {
        return _meshRenderer;
    }

    /// <summary>
    /// This method sets the MeshRenderer component associated with the game object.
    /// </summary>
    /// <param name="meshRenderer">The MeshRenderer component to set.</param>
    public void SetMeshRenderer(MeshRenderer meshRenderer)
    {
        _meshRenderer = meshRenderer;
    }

    /// <summary>
    /// This method gets the AudioSource component associated with the game object.
    /// </summary>
    /// <returns>The stored AudioSource component.</returns>
    public AudioSource GetAudioSource()
    {
        return _audioSource;
    }

    /// <summary>
    /// This method sets the AudioSource component associated with the game object.
    /// </summary>
    /// <param name="audioSource">The AudioSource component to set.</param>
    public void SetAudioSource(AudioSource audioSource)
    {
        _audioSource = audioSource;
    }

    /// <summary>
    /// This method gets the Animator component associated with the game object.
    /// </summary>
    /// <returns>The stored Animator component.</returns>
    public Animator GetAnimator()
    {
        return _animator;
    }

    /// <summary>
    /// This method sets the Animator component associated with the game object.
    /// </summary>
    /// <param name="animator">The Animator component to set.</param>
    public void SetAnimator(Animator animator)
    {
        _animator = animator;
    }

    /// <summary>
    /// Default constructor with no parameters.
    /// </summary>
    public DataRecord()
    {
        // No initialization here.
    }

    /// <summary>
    /// Constructor with parameters to initialize the data record.
    /// </summary>
    public DataRecord(Transform transform, string name, int layer, string tag,
                      bool activeSelf, bool activeInHierarchy, Component[] components,
                      Rigidbody rigidbody, Collider collider, MeshRenderer meshRenderer,
                      AudioSource audioSource, Animator animator)
    {
        _transform = transform;
        _name = name;
        _layer = layer;
        _tag = tag;
        _activeSelf = activeSelf;
        _activeInHierarchy = activeInHierarchy;
        _components = components;
        _rigidbody = rigidbody;
        _collider = collider;
        _meshRenderer = meshRenderer;
        _audioSource = audioSource;
        _animator = animator;
    }
}
