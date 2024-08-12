namespace Packt.Shared;

[Flags]
public enum WondersOfTheAncientWorld : byte
{
  None                      = 0b0000_0000,
  GreatPyramidOfGiza        = 0b0000_0001,
  HangingGardensOfBabylon   = 0b0000_0010,
  StatueOfZeusAtOlympia     = 0b0000_0100,
  TempleOfArtemisAtEphesus  = 0b0000_1000,
  MausoleumAtHalicarnassus  = 0b0001_0000,
  ColossusOfRhodes          = 0b0010_0000,
  LighthouseOfAlexandria    = 0b0100_0000
}