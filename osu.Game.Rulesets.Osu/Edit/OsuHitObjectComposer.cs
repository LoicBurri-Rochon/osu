// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Timing;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Edit;
using osu.Game.Rulesets.Edit.Layers.Selection;
using osu.Game.Rulesets.Edit.Tools;
using osu.Game.Rulesets.Osu.Edit.Layers.Selection;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Rulesets.Osu.UI;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Osu.Edit
{
    public class OsuHitObjectComposer : HitObjectComposer
    {
        public OsuHitObjectComposer(Ruleset ruleset, IAdjustableClock adjustableClock, IFrameBasedClock framedClock)
            : base(ruleset, adjustableClock, framedClock)
        {
        }

        protected override RulesetContainer CreateRulesetContainer(Ruleset ruleset, WorkingBeatmap beatmap) => new OsuEditRulesetContainer(ruleset, beatmap, true);

        protected override IReadOnlyList<ICompositionTool> CompositionTools => new ICompositionTool[]
        {
            new HitObjectCompositionTool<HitCircle>(),
            new HitObjectCompositionTool<Slider>(),
            new HitObjectCompositionTool<Spinner>()
        };

        protected override ScalableContainer CreateLayerContainer() => new ScalableContainer(OsuPlayfield.BASE_SIZE.X) { RelativeSizeAxes = Axes.Both };

        protected override HitObjectOverlayLayer CreateHitObjectOverlayLayer() => new OsuHitObjectOverlayLayer();
    }
}
