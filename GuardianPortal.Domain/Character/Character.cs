using System;

namespace GuardianPortal.Domain.Character
{
    public class Character {
        public long MembershipId { get; set; }
        public long CharacterId { get; set; }
        public DateTime DateLastPlayed { get; set; }
        public long MinutesPlayedTotal { get; set; }
        public int Light { get; set; }
        public uint RaceHash { get; set; }
        public RaceDefinition RaceDefinition {
            get { return (RaceDefinition)RaceHash; }
        }
        public string RaceDisplay { get { return RaceDefinition.ToString(); } }
        public uint GenderHash { get; set; }
        public GenderDefinition GenderDefinition {
            get { return (GenderDefinition)GenderHash; }
        }
        public string GenderDisplay { get { return GenderDefinition.ToString(); } }
        public uint ClassHash { get; set; }
        public ClassDefinition ClassDefinition {
            get { return (ClassDefinition)ClassHash; }
        }
        public string ClassDisplay { get { return ClassDefinition.ToString(); } }
        public string EmblemPath { get; set; }
        public string EmblemBackgroundPath { get; set; }
        public uint EmblemHash { get; set; }
        public int BaseCharacterLevel { get; set; }
        public uint TitleRecordHash { get; set; }
        public string TestProperty { get; set; } = "test";
    }
    // These enums are all SHITTY. Find a better way to derive them from the manifest and cache them somehow
    public enum RaceDefinition : uint
    {
        Human = 3887404748,
        Exo = 898834093,
        Awoken = 2803282938
    }
    public enum GenderDefinition : uint
    {
        Male = 3111576190,
        Female = 2204441813
    }

    public enum ClassDefinition : uint
    {
        Warlock = 2271682572,
        Titan = 3655393761,
        Hunter = 671679327
    }
}
