using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trida pro jeden blok
public class Block
{
    public BlockType Type;

    //Konstruktor
    public Block(BlockType Type)
    {
        this.Type = Type;
    }
    //Metoda zjistujici jestli je povrch pevny
    public bool IsSolid()
    {
        return Type != BlockType.Air;
    }
}
