﻿using Figgle;

namespace Testing;

public class TestingFiggle
{
    public static List<Func<string, string>> GetList()
    {
        return new()
        {
            input => FiggleFonts.OneRow.Render(input),
            input => FiggleFonts.ThreeD.Render(input),
            input => FiggleFonts.ThreeDDiagonal.Render(input),
            input => FiggleFonts.ThreeByFive.Render(input),
            input => FiggleFonts.FourMax.Render(input),
            input => FiggleFonts.FiveLineOblique.Render(input),
            input => FiggleFonts.Acrobatic.Render(input),
            input => FiggleFonts.Alligator.Render(input),
            input => FiggleFonts.Alligator2.Render(input),
            input => FiggleFonts.Alligator3.Render(input),
            input => FiggleFonts.Alpha.Render(input),
            input => FiggleFonts.Alphabet.Render(input),
            input => FiggleFonts.Amc3Line.Render(input),
            input => FiggleFonts.Amc3Liv1.Render(input),
            input => FiggleFonts.AmcAaa01.Render(input),
            input => FiggleFonts.AmcNeko.Render(input),
            input => FiggleFonts.AmcRazor2.Render(input),
            input => FiggleFonts.AmcRazor.Render(input),
            input => FiggleFonts.AmcSlash.Render(input),
            input => FiggleFonts.AmcSlder.Render(input),
            input => FiggleFonts.AmcThin.Render(input),
            input => FiggleFonts.AmcTubes.Render(input),
            input => FiggleFonts.AmcUn1.Render(input),
            input => FiggleFonts.Arrows.Render(input),
            input => FiggleFonts.AsciiNewroman.Render(input),
            input => FiggleFonts.Avatar.Render(input),
            input => FiggleFonts.B1FF.Render(input),
            input => FiggleFonts.Banner.Render(input),
            input => FiggleFonts.Banner3.Render(input),
            input => FiggleFonts.Banner3D.Render(input),
            input => FiggleFonts.Banner4.Render(input),
            input => FiggleFonts.BarbWire.Render(input),
            input => FiggleFonts.Basic.Render(input),
            input => FiggleFonts.Bear.Render(input),
            input => FiggleFonts.Bell.Render(input),
            input => FiggleFonts.Benjamin.Render(input),
            input => FiggleFonts.Big.Render(input),
            input => FiggleFonts.BigChief.Render(input),
            input => FiggleFonts.BigFig.Render(input),
            input => FiggleFonts.Binary.Render(input),
            input => FiggleFonts.Block.Render(input),
            input => FiggleFonts.Blocks.Render(input),
            input => FiggleFonts.Bolger.Render(input),
            input => FiggleFonts.Braced.Render(input),
            input => FiggleFonts.Bright.Render(input),
            input => FiggleFonts.Broadway.Render(input),
            input => FiggleFonts.BroadwayKB.Render(input),
            input => FiggleFonts.Bubble.Render(input),
            input => FiggleFonts.Bulbhead.Render(input),
            input => FiggleFonts.Caligraphy2.Render(input),
            input => FiggleFonts.Caligraphy.Render(input),
            input => FiggleFonts.Cards.Render(input),
            input => FiggleFonts.CatWalk.Render(input),
            input => FiggleFonts.Chiseled.Render(input),
            input => FiggleFonts.Chunky.Render(input),
            input => FiggleFonts.Coinstak.Render(input),
            input => FiggleFonts.Cola.Render(input),
            input => FiggleFonts.Colossal.Render(input),
            input => FiggleFonts.Computer.Render(input),
            input => FiggleFonts.Contessa.Render(input),
            input => FiggleFonts.Contrast.Render(input),
            input => FiggleFonts.Cosmic.Render(input),
            input => FiggleFonts.Cosmike.Render(input),
            //input => FiggleFonts.Crawford.Render(input),
            input => FiggleFonts.Crazy.Render(input),
            input => FiggleFonts.Cricket.Render(input),
            input => FiggleFonts.Cursive.Render(input),
            input => FiggleFonts.CyberLarge.Render(input),
            input => FiggleFonts.CyberMedium.Render(input),
            input => FiggleFonts.CyberSmall.Render(input),
            input => FiggleFonts.Cygnet.Render(input),
            input => FiggleFonts.DANC4.Render(input),
            input => FiggleFonts.DancingFont.Render(input),
            input => FiggleFonts.Decimal.Render(input),
            input => FiggleFonts.DefLeppard.Render(input),
            input => FiggleFonts.Diamond.Render(input),
            input => FiggleFonts.DietCola.Render(input),
            input => FiggleFonts.Digital.Render(input),
            input => FiggleFonts.Doh.Render(input),
            input => FiggleFonts.Doom.Render(input),
            input => FiggleFonts.DosRebel.Render(input),
            input => FiggleFonts.DotMatrix.Render(input),
            input => FiggleFonts.Double.Render(input),
            input => FiggleFonts.DoubleShorts.Render(input),
            input => FiggleFonts.DRPepper.Render(input),
            input => FiggleFonts.DWhistled.Render(input),
            input => FiggleFonts.EftiChess.Render(input),
            input => FiggleFonts.EftiFont.Render(input),
            input => FiggleFonts.EftiPiti.Render(input),
            input => FiggleFonts.EftiRobot.Render(input),
            input => FiggleFonts.EftiItalic.Render(input),
            input => FiggleFonts.EftiWall.Render(input),
            input => FiggleFonts.EftiWater.Render(input),
            input => FiggleFonts.Epic.Render(input),
            input => FiggleFonts.Fender.Render(input),
            input => FiggleFonts.Filter.Render(input),
            input => FiggleFonts.FireFontK.Render(input),
            input => FiggleFonts.FireFontS.Render(input),
            input => FiggleFonts.Flipped.Render(input),
            input => FiggleFonts.FlowerPower.Render(input),
            input => FiggleFonts.FourTops.Render(input),
            input => FiggleFonts.Fraktur.Render(input),
            input => FiggleFonts.FunFace.Render(input),
            input => FiggleFonts.FunFaces.Render(input),
            input => FiggleFonts.Fuzzy.Render(input),
            input => FiggleFonts.Georgia16.Render(input),
            input => FiggleFonts.Georgia11.Render(input),
            input => FiggleFonts.Ghost.Render(input),
            input => FiggleFonts.Ghoulish.Render(input),
            input => FiggleFonts.Glenyn.Render(input),
            input => FiggleFonts.Goofy.Render(input),
            input => FiggleFonts.Gothic.Render(input),
            input => FiggleFonts.Graceful.Render(input),
            input => FiggleFonts.Gradient.Render(input),
            input => FiggleFonts.Graffiti.Render(input),
            input => FiggleFonts.Greek.Render(input),
            input => FiggleFonts.HeartLeft.Render(input),
            input => FiggleFonts.HeartRight.Render(input),
            input => FiggleFonts.Henry3d.Render(input),
            input => FiggleFonts.Hex.Render(input),
            input => FiggleFonts.Hieroglyphs.Render(input),
            input => FiggleFonts.Hollywood.Render(input),
            input => FiggleFonts.HorizontalLeft.Render(input),
            input => FiggleFonts.HorizontalRight.Render(input),
            input => FiggleFonts.ICL1900.Render(input),
            input => FiggleFonts.Impossible.Render(input),
            input => FiggleFonts.Invita.Render(input),
            input => FiggleFonts.Isometric1.Render(input),
            input => FiggleFonts.Isometric2.Render(input),
            input => FiggleFonts.Isometric3.Render(input),
            input => FiggleFonts.Isometric4.Render(input),
            input => FiggleFonts.Italic.Render(input),
            input => FiggleFonts.Ivrit.Render(input),
            input => FiggleFonts.Jacky.Render(input),
            input => FiggleFonts.Jazmine.Render(input),
            input => FiggleFonts.Jerusalem.Render(input),
            input => FiggleFonts.Katakana.Render(input),
            input => FiggleFonts.Kban.Render(input),
            input => FiggleFonts.Keyboard.Render(input),
            input => FiggleFonts.Knob.Render(input),
            input => FiggleFonts.Konto.Render(input),
            input => FiggleFonts.KontoSlant.Render(input),
            input => FiggleFonts.Larry3d.Render(input),
            input => FiggleFonts.Lcd.Render(input),
            input => FiggleFonts.Lean.Render(input),
            input => FiggleFonts.Letters.Render(input),
            input => FiggleFonts.LilDevil.Render(input),
            input => FiggleFonts.LineBlocks.Render(input),
            input => FiggleFonts.Linux.Render(input),
            input => FiggleFonts.LockerGnome.Render(input),
            input => FiggleFonts.Madrid.Render(input),
            input => FiggleFonts.Marquee.Render(input),
            input => FiggleFonts.MaxFour.Render(input),
            input => FiggleFonts.Merlin1.Render(input),
            input => FiggleFonts.Merlin2.Render(input),
            input => FiggleFonts.Mike.Render(input),
            input => FiggleFonts.Mini.Render(input),
            input => FiggleFonts.Mirror.Render(input),
            input => FiggleFonts.Mnemonic.Render(input),
            input => FiggleFonts.Modular.Render(input),
            input => FiggleFonts.Morse.Render(input),
            input => FiggleFonts.Morse2.Render(input),
            input => FiggleFonts.Moscow.Render(input),
            input => FiggleFonts.Mshebrew210.Render(input),
            input => FiggleFonts.Muzzle.Render(input),
            input => FiggleFonts.NancyJ.Render(input),
            input => FiggleFonts.NancyJFancy.Render(input),
            input => FiggleFonts.NancyJImproved.Render(input),
            input => FiggleFonts.NancyJUnderlined.Render(input),
            input => FiggleFonts.Nipples.Render(input),
            input => FiggleFonts.NScript.Render(input),
            input => FiggleFonts.NTGreek.Render(input),
            input => FiggleFonts.NVScript.Render(input),
            input => FiggleFonts.O8.Render(input),
            input => FiggleFonts.Octal.Render(input),
            input => FiggleFonts.Ogre.Render(input),
            input => FiggleFonts.OldBanner.Render(input),
            input => FiggleFonts.OS2.Render(input),
            input => FiggleFonts.Pawp.Render(input),
            input => FiggleFonts.Peaks.Render(input),
            input => FiggleFonts.PeaksSlant.Render(input),
            input => FiggleFonts.Pebbles.Render(input),
            input => FiggleFonts.Pepper.Render(input),
            input => FiggleFonts.Poison.Render(input),
            input => FiggleFonts.Puffy.Render(input),
            input => FiggleFonts.Puzzle.Render(input),
            input => FiggleFonts.Pyramid.Render(input),
            input => FiggleFonts.Rammstein.Render(input),
            input => FiggleFonts.Rectangles.Render(input),
            input => FiggleFonts.RedPhoenix.Render(input),
            input => FiggleFonts.Relief.Render(input),
            input => FiggleFonts.Relief2.Render(input),
            input => FiggleFonts.Rev.Render(input),
            input => FiggleFonts.Reverse.Render(input),
            input => FiggleFonts.Roman.Render(input),
            input => FiggleFonts.Rot13.Render(input),
            input => FiggleFonts.Rotated.Render(input),
            input => FiggleFonts.Rounded.Render(input),
            input => FiggleFonts.RowanCap.Render(input),
            input => FiggleFonts.Rozzo.Render(input),
            input => FiggleFonts.Runic.Render(input),
            input => FiggleFonts.Runyc.Render(input),
            input => FiggleFonts.SantaClara.Render(input),
            input => FiggleFonts.SBlood.Render(input),
            input => FiggleFonts.Script.Render(input),
            input => FiggleFonts.ScriptSlant.Render(input),
            input => FiggleFonts.SerifCap.Render(input),
            input => FiggleFonts.Shadow.Render(input),
            input => FiggleFonts.Shimrod.Render(input),
            input => FiggleFonts.Short.Render(input),
            input => FiggleFonts.Slant.Render(input),
            input => FiggleFonts.Slide.Render(input),
            input => FiggleFonts.Small.Render(input),
            input => FiggleFonts.SmallCaps.Render(input),
            input => FiggleFonts.IsometricSmall.Render(input),
            input => FiggleFonts.KeyboardSmall.Render(input),
            input => FiggleFonts.PoisonSmall.Render(input),
            input => FiggleFonts.ScriptSmall.Render(input),
            input => FiggleFonts.ShadowSmall.Render(input),
            input => FiggleFonts.SlantSmall.Render(input),
            input => FiggleFonts.TengwarSmall.Render(input),
            input => FiggleFonts.Soft.Render(input),
            input => FiggleFonts.Speed.Render(input),
            input => FiggleFonts.Spliff.Render(input),
            input => FiggleFonts.SRelief.Render(input),
            input => FiggleFonts.Stacey.Render(input),
            input => FiggleFonts.Stampate.Render(input),
            input => FiggleFonts.Stampatello.Render(input),
            input => FiggleFonts.Standard.Render(input),
            input => FiggleFonts.Starstrips.Render(input),
            input => FiggleFonts.Starwars.Render(input),
            input => FiggleFonts.Stellar.Render(input),
            input => FiggleFonts.Stforek.Render(input),
            input => FiggleFonts.Stop.Render(input),
            input => FiggleFonts.Straight.Render(input),
            input => FiggleFonts.SubZero.Render(input),
            input => FiggleFonts.Swampland.Render(input),
            input => FiggleFonts.Swan.Render(input),
            input => FiggleFonts.Sweet.Render(input),
            input => FiggleFonts.Tanja.Render(input),
            input => FiggleFonts.Tengwar.Render(input),
            input => FiggleFonts.Term.Render(input),
            input => FiggleFonts.Test1.Render(input),
            input => FiggleFonts.Thick.Render(input),
            input => FiggleFonts.Thin.Render(input),
            input => FiggleFonts.ThreePoint.Render(input),
            input => FiggleFonts.Ticks.Render(input),
            input => FiggleFonts.TicksSlant.Render(input),
            input => FiggleFonts.Tiles.Render(input),
            input => FiggleFonts.TinkerToy.Render(input),
            input => FiggleFonts.Tombstone.Render(input),
            input => FiggleFonts.Train.Render(input),
            input => FiggleFonts.Trek.Render(input),
            input => FiggleFonts.Tsalagi.Render(input),
            input => FiggleFonts.Tubular.Render(input),
            input => FiggleFonts.Twisted.Render(input),
            input => FiggleFonts.TwoPoint.Render(input),
            input => FiggleFonts.Univers.Render(input),
            input => FiggleFonts.UsaFlag.Render(input),
            input => FiggleFonts.Varsity.Render(input),
            input => FiggleFonts.Wavy.Render(input),
            input => FiggleFonts.Weird.Render(input),
            input => FiggleFonts.WetLetter.Render(input),
            input => FiggleFonts.Whimsy.Render(input),
            input => FiggleFonts.Wow.Render(input)
        };
    }
}
