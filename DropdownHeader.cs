// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using OpenTK.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input;

namespace osu.Framework.Graphics.UserInterface
{   /// <summary>
    /// Abstract class of dropdownheader 
    /// </summary>
    public abstract class DropdownHeader : ClickableContainer
    {
        protected Container Background;
        protected Container Foreground;

        private Color4 backgroundColour = Color4.DarkGray;

        protected Color4 BackgroundColour   /// backgroundColour and background.Colour gets the value from the existing background 
        {
            get { return backgroundColour; }
            set
            {
                backgroundColour = value;
                Background.Colour = value;
            }
        }

        protected Color4 BackgroundColourHover { get; set; } = Color4.Gray;

        protected override Container<Drawable> Content => Foreground;

        protected internal abstract string Label { get; set; }
        /// <summary>
        /// The  class of DropdownHeader is the faded container that appears when you hover over the the menu.
        /// The internalchildren part is the function that enable the container to draw again.
        /// Also this make the children dynamic.
        /// </summary>
        protected DropdownHeader()  
        {
            Masking = true;
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
            Width = 1;
            InternalChildren = new Drawable[]
            {
                Background = new Container
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.DarkGray,
                    Child = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.White,
                    },
                },
                Foreground = new Container
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y
                },
            };
        }
        /// <summary>
        /// The onHover function set/updates the background colour according to what colour the BackgroundColourHover variable is set to.
        /// The fucntion also return the state as a boolean.
        /// </summary>
      
        protected override bool OnHover(InputState state)
        {
            Background.Colour = BackgroundColourHover;
            return base.OnHover(state);
        }
        /// <summary>
        /// The onHoverLost returns the background colour to the default valeue 
        /// The fucntion also return the state as a boolean.
        /// </summary>
        protected override void OnHoverLost(InputState state)
        {
            Background.Colour = BackgroundColour;
            base.OnHoverLost(state);
        }
    }
}
