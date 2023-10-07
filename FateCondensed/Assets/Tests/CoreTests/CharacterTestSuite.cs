using System.Collections.Generic;
using FateCondensed;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterTestSuite
{
    private CharacterBuilder _characterBuilder;
    private List<ScriptableObject> _listOfScriptableObjects;
    
    [SetUp]
    public void Setup()
    {
        _characterBuilder = new CharacterBuilder("Test");
        _listOfScriptableObjects = new List<ScriptableObject>();
    }
    
    [TearDown]
    public void TearDown()
    {
        // Destroy any ScriptableObjects created during the test
        foreach (var obj in _listOfScriptableObjects)
        {
            Object.DestroyImmediate(obj);
        }
    }

    [Test]
    public void CreateCharacterWithName()
    {
        var character = _characterBuilder.Build();
        Assert.AreEqual("Test", character.Name);
        Assert.NotNull(character);
    }

    [Test]
    public void AddAspect()
    {
        var firstAspect = new Aspect();
        _characterBuilder.AddAspect(firstAspect);
        
        var secondAspect = new Aspect
        {
            Name = "I have no character whatsoever.",
            Description = "I'm easily manipulated but I have high empathy.",
            Type = EAspectType.Trouble
        };
        _characterBuilder.AddAspect(secondAspect);
        
        var character = _characterBuilder.Build();
        Assert.AreEqual(2, character.Aspects.Count);
    }

    [Test]
    public void InitializeSkills_SetsDefaultModifiers()
    {
        var academics = ScriptableObject.CreateInstance<Skill>();
        academics.SkillName = "Academics";
        _listOfScriptableObjects.Add(academics);
        
        var archery = ScriptableObject.CreateInstance<Skill>();
        archery.SkillName = "Archery";
        _listOfScriptableObjects.Add(archery);
        
        _characterBuilder.InitializeSkills(new List<Skill> { academics, archery });
        var john = _characterBuilder.Build();
        
        Assert.AreEqual(0, john.ModifierBySkill[academics]);
        Assert.AreEqual(0, john.ModifierBySkill[archery]);
    }
    
    [Test]
    public void AddStunt()
    {
        var firstStunt = new Stunt();
        _characterBuilder.AddStunt(firstStunt);

        var secondStunt = new Stunt
        {
            Name = "Swordmaster",
            Description = "I can easily kill with a sword."
        };
        _characterBuilder.AddStunt(secondStunt);
        
        var character = _characterBuilder.Build();
        Assert.AreEqual(2, character.Stunts.Count);
    }
    
    [Test]
    public void ModifySkillsWithInvokingAspects()
    {
        var archery = ScriptableObject.CreateInstance<Skill>();
        archery.SkillName = "Archery";
        
        _listOfScriptableObjects.Add(archery);
        
        var archeryAspect = new Aspect
        {
            Name = "Master of Longbows",
            RelatedSkill = archery
        };

        var character = _characterBuilder
            .InitializeSkills(new List<Skill> { archery })
            .AddAspect(archeryAspect)
            .Build();

        Assert.AreEqual(3, character.FatePoints);
        
        character.InvokeAspect(archeryAspect);
        
        Assert.AreEqual(2, character.ModifierBySkill[archery]);
        Assert.AreEqual(2, character.FatePoints);

        character.EndAspect(archeryAspect);
        
        Assert.AreEqual(0, character.ModifierBySkill[archery]);
    }
}
