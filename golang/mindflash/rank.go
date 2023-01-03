package main

/**
 * 一个简单的排行榜的实现，包含两个数据结构，
 * 	1. 有序的元素数组
 * 	2. 每个数组对应排名的映射
 * © 2015-2023 TIAOYU, All rights reserved.
 **/

type RankKey int64
type RankVal struct {
	Value int
}

func (r *RankVal) Compare(rv *RankVal) int {
	return r.Value - rv.Value
}
func (r *RankVal) Set(v interface{}) {
	r.Value = v.(int)
}
func (r *RankVal) Get() interface{} {
	return r.Value
}

type RankValInterface interface {
	Compare(rv RankValInterface) int
	Set(v interface{})
	Get() interface{}
}
type Entity struct {
	ID  RankKey
	Val *RankVal
}

type Rank struct {
	Entities   []*Entity       // 榜内元素 有序
	EntityRank map[RankKey]int // 榜内元素的index 用于快速查找元素的排名
}

/**
 * 更新榜内某个元素，默认为升序排列，
 * 	1. 如果元素在榜首或榜尾 则只需要比较前后元素的大小
 * 	2. 如果元素在榜中 则需要比较前后元素的大小
 * 判断是否需要移动元素的依据是当前元素与前后元素的大小关系，通过冒泡排序，每次插入一个元素可以在O(n)的时间内完成有序的插入。
 * 	1. 如果当前元素比后面的元素大 则需要将后面较小的元素往前移 并更新index
 * 	2. 如果当前元素比前面的元素小 则需要将前面较大的值后移 并更新index
 */
func (r *Rank) Update(e *Entity) {
	k := r.GetRank(e.ID)
	rlen := len(r.Entities)
	if rlen < k {
		return
	}

	r.Entities[k].Val.Set(e.Val.Get())
	if rlen == 1 {
		return
	}
	inc := 0
	if k == 0 {
		if r.Entities[1].Val.Compare(r.Entities[k].Val) > 0 {
			inc = 1
		}
	} else if k == rlen-1 {
		if r.Entities[k-1].Val.Compare(r.Entities[k].Val) > 0 {
			inc = -1
		}
	} else {
		if r.Entities[1].Val.Compare(r.Entities[k].Val) > 0 {
			inc = 1
		} else if r.Entities[k-1].Val.Compare(r.Entities[k].Val) > 0 {
			inc = -1
		}
	}
	if inc == 0 {
		return
	}
	for i := k + inc; i >= 0 && i < rlen; i += inc {
		if inc > 0 {
			// 当前元素比后面的大 需要将后面较小的元素往前移 并更新index
			if e.Val.Compare(r.Entities[i].Val) > 0 {
				r.Entities[i-inc] = r.Entities[i]
				r.EntityRank[r.Entities[i].ID] = i - inc
				r.Entities[i] = e
				r.EntityRank[e.ID] = i
			} else {
				r.Entities[i-inc] = e
				r.EntityRank[e.ID] = i - inc
				break
			}
		} else {
			// 当前元素比前面的小 需要将前面较大的值后移 并更新index
			if e.Val.Compare(r.Entities[i].Val) < 0 {
				r.Entities[i-inc] = r.Entities[i]
				r.EntityRank[r.Entities[i].ID] = i - inc
				r.Entities[i] = e
				r.EntityRank[e.ID] = i
			} else {
				r.Entities[i-inc] = e
				r.EntityRank[e.ID] = i - inc
				break
			}
		}
	}
}

// 获取某个元素的排名
func (r *Rank) GetRank(k RankKey) int {
	return r.EntityRank[k]
}

// 插入一个元素
func (r *Rank) Insert(e *Entity) {
	r.Entities = append(r.Entities, e)
	r.EntityRank[e.ID] = len(r.Entities) - 1

	// 更新排名
	r.Update(e)
}
