# Installation

> [!NOTE]
> The SODD Framework requires Unity version 2022.3 or later.

To integrate the **SODD Framework** into your Unity project, follow one of the two methods below:

## Installation via Package Manager

1. In your project, open the Package Manager by going to `Window` > `Package Manager`.
2. In the Package Manager, click on the `+` icon in the top left corner and select '**Add package from git URL**'. For
   more detailed instructions, see
   the [Unity documentation on installing from a Git URL](https://docs.unity3d.com/2021.2/Documentation/Manual/upm-ui-giturl.html).
3. Enter the following URL into the text field and click '**Add**':
   ```
   https://github.com/aruizrab/sodd-unity-framework.git
   ```

> [!IMPORTANT]  
> The SODD Framework requires
> Unity's [Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest)
> and [TextMeshPro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@latest) packages. If it is
> not already installed in your project, Unity will prompt you to install it as a dependency when adding the SODD
> Framework.

## Manual Installation

1. Download the source code of the latest release from
   the [SODD Framework releases page](https://github.com/aruizrab/sodd-unity-framework/releases).
2. Uncompress the downloaded file into your Unity project's `Assets` folder.

> [!IMPORTANT]  
> Before uncompressing the SODD Framework source code, ensure
> that [Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest)
> and [TextMeshPro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@latest) are installed in your Unity project to
> avoid compilation errors:
