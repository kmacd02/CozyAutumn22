using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class SpecialRuleTile : RuleTile<SpecialRuleTile.Neighbor> {
    public TileBase edge;
    
    public class Neighbor : RuleTile.TilingRule.Neighbor
    {
        public const int Edge = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.Edge: return tile == edge;
            case Neighbor.This: return tile != null;
            case Neighbor.NotThis: return tile == null;
        }
        return base.RuleMatch(neighbor, tile);
    }
}