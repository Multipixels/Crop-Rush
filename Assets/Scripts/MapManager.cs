using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Map {

    static readonly int[,] level0 = new int[3, 9] {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 4, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    static readonly int[,] level1 = new int[7, 9] {
        { 1, 1, 1, 1, 1, 0, 0, 0, 0 },
        { 1, 2, 2, 2, 1, 1, 1, 1, 1 },
        { 1, 2, 1, 2, 1, 2, 2, 2, 1 },
        { 1, 2, 1, 2, 1, 2, 1, 2, 1 },
        { 1, 4, 1, 2, 1, 1, 1, 2, 1 },
        { 1, 1, 1, 2, 2, 2, 2, 2, 1 },
        { 0, 0, 1, 1, 1, 1, 1, 1, 1 }
    };

    static readonly int[,] level2 = new int[7, 11] {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 4, 2, 2, 1, 2, 2, 2, 2, 2, 1 },
        { 1, 2, 2, 2, 1, 2, 2, 2, 1, 2, 1 },
        { 1, 2, 2, 2, 1, 1, 1, 2, 1, 2, 1 },
        { 1, 2, 1, 1, 1, 2, 2, 2, 1, 2, 1 },
        { 1, 2, 2, 2, 2, 2, 2, 2, 1, 2, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    static readonly int[,] level3 = new int[9, 15] {
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 1 },
        { 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 1, 2, 1, 2, 2, 2, 1, 2, 2, 2, 2, 1, 2, 1 },
        { 1, 2, 2, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1 },
        { 1, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 2, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    static readonly int[,] level4 = new int[11, 15] {
        { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 2, 2, 2, 1, 2, 1, 2, 1, 1, 1, 1, 2, 2, 1 },
        { 1, 2, 1, 2, 2, 5, 2, 5, 2, 2, 2, 2, 2, 1, 1 },
        { 1, 2, 1, 1, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 0 },
        { 1, 2, 1, 0, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 0 },
        { 1, 2, 1, 0, 1, 2, 2, 5, 2, 2, 2, 2, 2, 1, 1 },
        { 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 2, 2, 2, 1 },
        { 1, 2, 2, 2, 2, 2, 2, 5, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 }
    };

    static readonly int[,] level5 = new int[10, 14] {
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 2, 2, 1 },
        { 0, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 2, 1 },
        { 0, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 2, 1 },
        { 0, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 2, 1 },
        { 0, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 2, 1 },
        { 0, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 2, 1 },
        { 1, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 2, 1 },
        { 1, 4, 5, 2, 5, 2, 5, 2, 5, 2, 5, 2, 2, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    static readonly int[,] level6 = new int[17, 19] {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 4, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1 },
        { 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 1, 2, 1 },
        { 1, 5, 1, 2, 2, 2, 1, 0, 0, 1, 2, 2, 2, 1, 2, 2, 2, 2, 1 },
        { 1, 5, 1, 2, 1, 2, 1, 1, 1, 1, 2, 1, 2, 1, 2, 1, 2, 1, 1 },
        { 1, 5, 1, 2, 2, 5, 2, 2, 2, 2, 5, 2, 2, 1, 2, 1, 5, 1, 0 },
        { 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 5, 1, 0 },
        { 1, 5, 1, 0, 0, 0, 0, 0, 0, 1, 2, 1, 0, 1, 2, 1, 5, 1, 0 },
        { 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 5, 1, 0 },
        { 1, 5, 5, 5, 2, 2, 2, 2, 2, 2, 5, 2, 2, 1, 2, 1, 5, 1, 0 },
        { 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 2, 1, 2, 1, 2, 1, 5, 1, 0 },
        { 0, 0, 1, 1, 2, 1, 0, 0, 0, 1, 2, 2, 2, 1, 2, 1, 5, 1, 1 },
        { 0, 0, 0, 1, 2, 1, 0, 0, 0, 1, 1, 1, 1, 1, 2, 1, 5, 2, 1 },
        { 0, 0, 1, 1, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 5, 5, 2, 2, 1 },
        { 0, 0, 1, 2, 5, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 2, 2, 2, 1 },
        { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1 }
    };

    static readonly int[,] level7 = new int[12, 15] {
        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 4, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 1, 1, 1, 2, 1, 1, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 1, 0, 0, 0, 0 },
        { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1 },
        { 1, 2, 2, 2, 2, 2, 2, 5, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 2, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1, 2, 1 },
        { 1, 2, 1, 2, 5, 5, 5, 5, 5, 5, 5, 2, 1, 2, 1 },
        { 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 },
        { 1, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    static readonly int[,] level8 = new int[17, 19] {
        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 2, 1, 1, 1, 2, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 2, 1, 6, 1, 2, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 1, 1, 1, 2, 1, 8, 1, 2, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 0, 0, 1, 1, 2, 2, 2, 2, 5, 2, 2, 1, 2, 2, 2, 2, 2, 1 },
        { 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 1, 1, 2, 1 },
        { 1, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 0, 1, 2, 1 },
        { 1, 2, 4, 2, 2, 7, 2, 1, 2, 2, 1, 1, 1, 1, 1, 0, 1, 6, 1 },
        { 1, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 0, 1, 2, 1 },
        { 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 1, 1, 2, 1 },
        { 0, 0, 0, 1, 1, 2, 2, 2, 2, 5, 2, 2, 1, 2, 2, 2, 2, 2, 1 },
        { 0, 0, 0, 0, 1, 1, 1, 2, 1, 8, 1, 2, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 1, 2, 1, 6, 1, 2, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 2, 1, 1, 1, 2, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 }
    };

    static readonly int[,] level9 = new int[25, 47] {
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 1, 0, 0, 0, 1, 1, 2, 2, 2, 2, 1, 0, 0, 1, 1, 2, 2, 2, 2, 1, 1, 1, 2, 2, 1, 1, 1, 0, 0, 1, 2, 2, 2, 2, 1 },
        { 1, 2, 6, 2, 2, 2, 2, 2, 7, 2, 2, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 0, 0, 1, 2, 2, 2, 2, 7, 2, 2, 2, 5, 5, 5, 6, 1, 0, 0, 1, 2, 2, 1, 2, 1 },
        { 1, 2, 2, 2, 1, 2, 2, 2, 2, 1, 1, 2, 1, 1, 2, 2, 1, 7, 1, 1, 2, 2, 1, 1, 1, 1, 2, 2, 1, 1, 2, 2, 2, 2, 2, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 2, 1 },
        { 1, 2, 2, 1, 1, 1, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 1, 2, 2, 2, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 2, 1 },
        { 1, 2, 2, 1, 0, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1, 1, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 0, 0, 1, 2, 6, 1, 2, 1 },
        { 1, 2, 2, 1, 0, 0, 1, 2, 2, 1, 1, 2, 2, 2, 1, 2, 2, 2, 1, 1, 1, 2, 2, 1, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 1, 0, 0, 1, 2, 2, 1, 2, 1 },
        { 1, 2, 2, 1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 0, 0, 1, 2, 2, 1, 2, 1 },
        { 1, 2, 2, 2, 1, 1, 2, 2, 1, 1, 0, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 2, 2, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 0, 1, 1, 2, 2, 1, 2, 1 },
        { 1, 2, 2, 2, 2, 2, 2, 2, 1, 0, 0, 1, 1, 2, 6, 2, 1, 1, 1, 1, 1, 2, 6, 2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 7, 2, 2, 7, 2, 1 },
        { 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 1 },
        { 0, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
        { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 1 },
        { 0, 1, 1, 2, 2, 2, 2, 2, 2, 7, 1, 2, 2, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 2, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 1, 1, 2, 1 },
        { 1, 1, 2, 2, 2, 6, 2, 1, 1, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 7, 2, 2, 2, 2, 1, 2, 7, 2, 2, 2, 1, 0, 1, 1, 1, 0, 0, 1, 2, 2, 1 },
        { 1, 2, 5, 2, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 7, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 1, 1, 1, 2, 1, 1, 0, 1, 2, 2, 1 },
        { 1, 2, 5, 2, 1, 1, 1, 1, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 1, 1, 1, 2, 2, 2, 1, 2, 2, 1, 1, 2, 2, 2, 1, 2, 2, 2, 1, 1, 5, 5, 1, 0, 1, 2, 2, 1 },
        { 1, 2, 2, 1, 1, 0, 0, 1, 2, 2, 1, 1, 1, 2, 2, 1, 2, 2, 2, 1, 0, 1, 1, 2, 2, 1, 2, 2, 1, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 5, 5, 1, 1, 1, 2, 2, 1 },
        { 1, 2, 2, 2, 1, 0, 0, 1, 2, 2, 1, 0, 1, 2, 2, 1, 1, 2, 2, 1, 0, 1, 1, 2, 2, 1, 5, 2, 1, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1, 5, 5, 1, 1, 2, 2, 2, 1 },
        { 1, 2, 2, 2, 1, 0, 0, 1, 2, 2, 1, 0, 1, 2, 2, 1, 1, 2, 2, 1, 1, 1, 2, 2, 1, 1, 5, 1, 1, 1, 2, 2, 2, 1, 1, 2, 2, 2, 1, 5, 5, 1, 1, 2, 2, 2, 1 },
        { 1, 2, 2, 2, 1, 0, 0, 1, 2, 2, 1, 0, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1, 2, 5, 1, 0, 1, 2, 2, 2, 1, 1, 2, 2, 2, 2, 5, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 2, 4, 2, 1, 0, 0, 1, 2, 2, 1, 0, 1, 2, 2, 1, 1, 2, 2, 2, 2, 2, 6, 2, 1, 2, 2, 1, 0, 1, 2, 6, 2, 1, 1, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
        { 1, 2, 2, 2, 1, 0, 0, 1, 2, 6, 1, 0, 1, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 1, 0, 1, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 1, 1, 2, 2, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }
    };

    public List<int[,]> levels = new List<int[,]>() {
        level0, level1, level2, level3, level4, level5 ,level6, level7, level8, level9
    };
}

public class MapManager : MonoBehaviour {

    [SerializeField]
    private AudioSource keyAudio;

    [SerializeField] 
    private AudioSource useKeyAudio;

    [SerializeField]
    private Tile tilePrefab;

    [SerializeField]
    private Transform cammy;

    public int level;

    [SerializeField]
    private Transform player;

    private readonly Map map = new Map();

    private Tile[,] mapTiles;

    private int tilesLeft;
    private int totalTiles;

    private float timeTaken;
    private int totalMoves;

    [SerializeField]
    private TMP_Text cropsCounter;
    [SerializeField]
    private TMP_Text movesCounter;
    [SerializeField]
    private TMP_Text timeCounter;
    [SerializeField]
    private TMP_Text keyCounterText;
    [SerializeField]
    private TMP_Text levelText;

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject winMenu;
    [SerializeField]
    private GameObject keyMenu;

    private int totalKeys;

    private bool gameActive;

    // Start is called before the first frame update

    public void Start() {
        int lvl = PlayerPrefs.GetInt("currentLevel", 0);
        StartGame(lvl);
    }
    public void StartGame(int lvl) {
        level = lvl;
        levelText.text = $"Level: {level+1}";
        GenerateField();
        gameActive = true;
        timeTaken = 0f;

        cropsCounter.text = $"Crops Left: {tilesLeft} / {totalTiles}";
        movesCounter.text = "Moves Taken: 0";
        //timeCounter.text = "Time: 00:00:00";

        totalKeys = 0;
        Time.timeScale = 1;
    }

    private void Update() {
        if (gameActive == true) {
            timeTaken += Time.deltaTime;
            //timeCounter.text = $"Time: {TimeSpan.FromSeconds(timeTaken).ToString("mm':'ss'.'ff")}";
        }
    }

    private void GenerateField() {

        mapTiles = new Tile[map.levels[level].GetLength(0), map.levels[level].GetLength(1)];

        for (int y = 0; y < map.levels[level].GetLength(0); y++) {
            for (int x = 0; x < map.levels[level].GetLength(1); x++) {
                Tile spawnedTile = Instantiate(tilePrefab, new Vector3(x, y, 1), Quaternion.identity);
                spawnedTile.name = $"Tile {x}, {y}";
                spawnedTile.GetComponent<Tile>().Initialize(map.levels[level][y, x]);

                if (map.levels[level][y, x] == 4) {
                    player.position = spawnedTile.transform.position;
                    player.position += new Vector3(0, 0, -1);
                }

                if (map.levels[level][y, x] == 2 || map.levels[level][y, x] == 6 || map.levels[level][y, x] == 7) {
                    tilesLeft += 1;
                    totalTiles += 1;
                } else if (map.levels[level][y, x] == 5 || map.levels[level][y, x] == 8) {
                    tilesLeft += 2;
                    totalTiles += 2;
                }

                mapTiles[y, x] = spawnedTile;
            }
        }

        cammy.transform.position = new Vector3((float)map.levels[level].GetLength(1) / 2 - 0.5f, (float)map.levels[level].GetLength(0) / 2 - 0.5f, -10);
        switch (level) {
            case 0: {
                    cammy.GetComponent<Camera>().orthographicSize = 4;
                    break;
                }
            case 1: {
                    cammy.GetComponent<Camera>().orthographicSize = 5;
                    break;
                }
            case 2: {
                    cammy.GetComponent<Camera>().orthographicSize = 5;
                    break;
                }
            case 3: {
                    cammy.GetComponent<Camera>().orthographicSize = 6;
                    break;
                }
            case 4: {
                    cammy.GetComponent<Camera>().orthographicSize = 6;
                    break;
                }
            case 5: {
                    cammy.GetComponent<Camera>().orthographicSize = 6;
                    break;
                }
            case 6: {
                    cammy.GetComponent<Camera>().orthographicSize = 10;
                    break;
                }
            case 7: {
                    cammy.GetComponent<Camera>().orthographicSize = 7;
                    break;
                }
            case 8: {
                    cammy.GetComponent<Camera>().orthographicSize = 10;
                    break;
                }
            case 9: {
                    cammy.GetComponent<Camera>().orthographicSize = 16;
                    break;
                }
        }
    }

    public bool PreMove(Vector2 desiredLocation) {
        int x = (int)desiredLocation.x;
        int y = (int)desiredLocation.y;
        int id = mapTiles[y, x].GetId();

        if (id == 1) {
            return false;
        }

        if (gameActive == false) {
            return false;
        }

        if ((id == 7 || id == 8) && totalKeys == 0) {
            return false;
        }

        return true;
    }
    public void PostMove(Transform newLocation) {
        int x = (int)newLocation.position.x;
        int y = (int)newLocation.position.y;

        totalMoves += 1;
        movesCounter.text = $"Moves Taken: {totalMoves}";

        if (mapTiles[y, x].GetId() == 2 || mapTiles[y, x].GetId() == 5) {
            tilesLeft -= 1;
        } else if (mapTiles[y, x].GetId() == 6) {
            tilesLeft -= 1;
            totalKeys += 1;
            keyMenu.SetActive(true);
            keyCounterText.text = $"{totalKeys}";

            keyAudio.volume = PlayerPrefs.GetFloat("audioVolume");
            keyAudio.Play();

        } else if (mapTiles[y, x].GetId() == 7 || mapTiles[y, x].GetId() == 8) {
            tilesLeft -= 1;
            totalKeys -= 1;
            keyCounterText.text = $"{totalKeys}";

            useKeyAudio.volume = PlayerPrefs.GetFloat("audioVolume");
            useKeyAudio.Play();
        }

        cropsCounter.text = $"Crops Left: {tilesLeft} / {totalTiles}";
        mapTiles[y, x].Progress();

        if (tilesLeft == 0) {
            Win();
        }

    }

    private void Win() {
        gameActive = false;
        Time.timeScale = 0;
        winMenu.SetActive(true);

        winMenu.transform.Find("WinMoves").GetComponent<TMP_Text>().text = $"Moves Taken: {totalMoves}";
        //winMenu.transform.Find("WinTime").GetComponent<TMP_Text>().text = timeCounter.text;

        //timeCounter.gameObject.transform.parent.gameObject.SetActive(false);
        movesCounter.gameObject.transform.parent.gameObject.SetActive(false);
        cropsCounter.gameObject.transform.parent.gameObject.SetActive(false);

        PlayerPrefs.SetInt($"{level}Stars", Math.Max(PlayerPrefs.GetInt($"{level}Stars"), 1));

        if (totalTiles / (float)totalMoves >= 0.8f) {
            winMenu.transform.Find("Star2Full").gameObject.SetActive(true);
            PlayerPrefs.SetInt($"{level}Stars", Math.Max(PlayerPrefs.GetInt($"{level}Stars"), 2));
        }

        if (totalTiles == totalMoves) {
            winMenu.transform.Find("Star3Full").gameObject.SetActive(true);
            PlayerPrefs.SetInt($"{level}Stars", Math.Max(PlayerPrefs.GetInt($"{level}Stars"), 3));
        }

    }

    public void Pause(InputAction.CallbackContext context) {
        if (context.performed && tilesLeft != 0) {
            PauseGame();
        }
    }

    public void PauseGame() {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        gameActive = !gameActive;

        if (Time.timeScale == 1) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
