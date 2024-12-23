# Unity Shared Preferences

Helper class that uses cookies in WebGL builds and [PlayerPrefs](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html) on other platforms.

## Motivation

Although Unity WebGL applications support `PlayerPrefs`, the storage is tightly bound to a specific build.
This means that the data stored there becomes inaccessible once you update your application.
That is why you should use cookies instead of `PlayerPrefs` to store persistent data.

## Dependencies

[Unity WebGL Cookies](https://github.com/Mini-IT/unity-web-cookies) package needed

## Installation

Use Unity Package Manager to [add the package](https://docs.unity3d.com/Manual/upm-ui-giturl.html) using the URL of this repository.

## Usage

```csharp
using MiniIT.Storage;

public class SharedPrefsExample
{
  public void DoSomething()
  {
    // Static methods
    string value = SharedPrefs.GetString("some.string.key", "Optional default value");
    SharedPrefs.SetInt("PlayerHealth", 100);

    // Local reference
    ISharedPrefs prefs = SharedPrefs.Instance;
    prefs.SetBool("SoundEnabled", true);
    float volume = prefs.GetFloat("MusicVolume", 1f);
  }
}
```
