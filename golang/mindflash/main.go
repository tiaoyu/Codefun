package main

import (
	"fmt"
	"math/rand"
)

func main() {
	var rank = &Rank{
		Entities:   make([]*Entity, 0, 16),
		EntityRank: make(map[RankKey]int),
	}
	for i := 0; i < 100; i++ {
		val := int(rand.Int63n(9999999999))
		rank.Insert(&Entity{
			ID: RankKey(i),
			Val: &RankVal{
				Value: val,
			},
		})
	}

	for _, v := range rank.Entities {
		fmt.Println(rank.EntityRank[v.ID], v.ID, v.Val.Get())
	}
}
