# Unity.SceneTransitions

Some simple scene transitions for unity

![Transition](/Documentation~/transition.gif?raw=true)

## Installation

Add these dependencies to your `manifest.json`

```json
{
  "dependencies": {
    "jd.boiv.in.extensions": "https://github.com/starburst997/Unity.Extensions.git",
    "jd.boiv.in.text": "https://github.com/starburst997/Unity.Text.git",
    "jd.boiv.in.tween": "https://github.com/starburst997/Unity.Tween.git",
    "jd.boiv.in.wait": "https://github.com/starburst997/Unity.Wait.git",
    "jd.boiv.in.scene-transitions": "https://github.com/starburst997/Unity.SceneTransitions.git"
  }
}
```

## Usage

```csharp
SceneTransition.Instance.Load("my-scene");
```
