using UnityEngine;

namespace DuloGames.UI
{
    public class ColorScheme : ScriptableObject
    {
        [Header("Image Colors")]
        [SerializeField] private Color m_ImagePrimary = Color.white;
        [SerializeField] private Color m_ImageSecondary = Color.white;
        [SerializeField] private Color m_ImageLight = Color.white;
        [SerializeField] private Color m_ImageDark = Color.white;
        [SerializeField] private Color m_ImageEffect = Color.white;
        [SerializeField] private Color m_ImageBordersPrimary = Color.white;
        [SerializeField] private Color m_ImageBordersSecondary = Color.white;

        [Header("Button Colors")]
        [SerializeField] private Color m_ButtonForeground = Color.white;

        [Header("Window Colors")]
        [SerializeField] private Color m_WindowHeader = Color.white;
        
        /// <summary>
        /// Gets or sets the Primary image color shade.
        /// </summary>
        public Color imagePrimary
        {
            get { return this.m_ImagePrimary; }
            set { this.m_ImagePrimary = value; }
        }

        /// <summary>
        /// Gets or sets the Secondary image color shade.
        /// </summary>
        public Color imageSecondary
        {
            get { return this.m_ImageSecondary; }
            set { this.m_ImageSecondary = value; }
        }

        /// <summary>
        /// Gets or sets the light image color shade.
        /// </summary>
        public Color imageLight
        {
            get { return this.m_ImageLight; }
            set { this.m_ImageLight = value; }
        }

        /// <summary>
        /// Gets or sets the dark image color shade.
        /// </summary>
        public Color imageDark
        {
            get { return this.m_ImageDark; }
            set { this.m_ImageDark = value; }
        }
        
        /// <summary>
        /// Gets or sets the Effect image color shade.
        /// </summary>
        public Color imageEffect
        {
            get { return this.m_ImageEffect; }
            set { this.m_ImageEffect = value; }
        }

        /// <summary>
        /// Gets or sets the Primary Borders image color shade.
        /// </summary>
        public Color imageBordersPrimary
        {
            get { return this.m_ImageBordersPrimary; }
            set { this.m_ImageBordersPrimary = value; }
        }

        /// <summary>
        /// Gets or sets the Secondary Borders image color shade.
        /// </summary>
        public Color imageBordersSecondary
        {
            get { return this.m_ImageBordersSecondary; }
            set { this.m_ImageBordersSecondary = value; }
        }

        /// <summary>
        /// Gets or sets the button foreground color.
        /// </summary>
        public Color buttonForeground
        {
            get { return this.m_ButtonForeground; }
            set { this.m_ButtonForeground = value; }
        }
        
        /// <summary>
        /// Gets or sets the window header color.
        /// </summary>
        public Color windowHeader
        {
            get { return this.m_WindowHeader; }
            set { this.m_WindowHeader = value; }
        }
        
        /// <summary>
        /// Applies the color scheme.
        /// </summary>
        public void ApplyColorScheme()
        {
            // Get all the color scheme elements in the scene
            ColorSchemeElement[] elements = Object.FindObjectsOfType<ColorSchemeElement>();

            foreach (ColorSchemeElement element in elements)
            {
                this.ApplyToElement(element);
            }

            ColorSchemeElement_SelectField[] selectElements = Object.FindObjectsOfType<ColorSchemeElement_SelectField>();

            foreach (ColorSchemeElement_SelectField element in selectElements)
            {
                this.ApplyToElement(element);
            }

            // Set the color scheme as active
            if (ColorSchemeManager.Instance != null)
                ColorSchemeManager.Instance.activeColorScheme = this;
        }
        
        /// <summary>
        /// Gets a color shade.
        /// </summary>
        /// <param name="shade">The shade.</param>
        /// <returns>The color.</returns>
        public Color GetColorShade(ColorSchemeShade shade)
        {
            Color newColor = Color.white;

            switch (shade)
            {
                case ColorSchemeShade.Primary:
                    newColor = this.m_ImagePrimary;
                    break;
                case ColorSchemeShade.Secondary:
                    newColor = this.m_ImageSecondary;
                    break;
                case ColorSchemeShade.Light:
                    newColor = this.m_ImageLight;
                    break;
                case ColorSchemeShade.Dark:
                    newColor = this.m_ImageDark;
                    break;
                case ColorSchemeShade.Effect:
                    newColor = this.m_ImageEffect;
                    break;
                case ColorSchemeShade.BordersPrimary:
                    newColor = this.m_ImageBordersPrimary;
                    break;
                case ColorSchemeShade.BordersSecondary:
                    newColor = this.m_ImageBordersSecondary;
                    break;
                case ColorSchemeShade.Button:
                    newColor = this.m_ButtonForeground;
                    break;
                case ColorSchemeShade.WindowHeader:
                    newColor = this.m_WindowHeader;
                    break;
            }

            return newColor;
        }


        /// <summary>
        /// Applies the color scheme to the specified element.
        /// </summary>
        /// <param name="element"></param>
        public void ApplyToElement(IColorSchemeElement element)
        {
            if (element == null)
                return;
            
            // Get the color
            Color newColor = this.GetColorShade(element.shade);

            // Apply
            element.Apply(newColor);
        }
    }
}
