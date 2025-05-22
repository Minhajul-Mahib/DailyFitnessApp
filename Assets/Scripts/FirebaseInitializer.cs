using UnityEngine;
using Firebase;
using Firebase.Extensions;

public class FirebaseInitializer : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            if (task.Result == DependencyStatus.Available)
            {
                Debug.Log("✅ Firebase is ready!");
            }
            else
            {
                Debug.LogError("❌ Could not resolve Firebase dependencies.");
            }
        });
    }
}
