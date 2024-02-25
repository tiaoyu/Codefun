package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
)

// 求字符串中所有字串是否包含前k个字母且长度为n的所有排列组合
// 思路：
// 在字符串中依次统计前k个字母是否出现，每正好全部都出现过，则重新统计，且保存最后一个字母；
// 最后统计的数字大于等于n，则输出YES，否则输出NO，然后再保存未能组成一组的缺失的任一个字母，并且不足n长度用 'a' 补齐
func CF1921A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	latin := "abcdefghijklmnopqrstuvwxyz"

	for t > 0 {
		t--
		n, k, m := r.NextInt(), r.NextInt(), r.NextInt()
		s := r.NextString()
		tmp := make(map[uint8]int)
		mlatin := make(map[uint8]struct{})
		for i := 0; i < k; i++ {
			mlatin[uint8(latin[i])] = struct{}{}
		}
		inx := 0
		ans := ""
		for i := 0; i < m; i++ {

			if s[i] <= uint8(latin[k-1]) {
				tmp[s[i]]++
			}
			if len(tmp) == k {
				tmp = make(map[uint8]int)
				inx++
				ans += string(s[i])
			}
		}

		if inx >= n {
			fmt.Println("YES")
		} else {
			for v := range tmp {
				delete(mlatin, v)
			}
			for v := range mlatin {
				ans += string(v)
				inx++
				break
			}
			for i := inx; i < n; i++ {
				ans += "a"
			}
			fmt.Println("NO")
			fmt.Println(ans)
		}
	}
}

// TLE
func CF1921B() {
	type Node struct {
		Last      *Node
		Next      *Node
		Number    int
		Value     int
		IsHarbour bool
	}
	r := NewR(bufio.NewReader(os.Stdin))
	n, m, q := r.NextInt(), r.NextInt(), r.NextInt()
	l := make([]*Node, n+1)
	harbour := make([]int, m)
	harbourNodes := make([]*Node, m)
	for i := 0; i < m; i++ {
		tmp := r.NextInt()
		harbour[i] = tmp
		harbourNodes[i] = &Node{Number: tmp, IsHarbour: true}
		l[tmp] = harbourNodes[i]
	}

	for i := 0; i < m; i++ {
		tmp := r.NextInt()
		harbourNodes[i].Value = tmp
		l[harbour[i]].Value = tmp
	}
	// 从1~n排序
	sort.Slice(harbourNodes, func(i, j int) bool {
		return harbourNodes[i].Number < harbourNodes[j].Number
	})

	var left, right *Node
	for i := 0; i < m; i++ {
		if harbourNodes[i].IsHarbour && left == nil {
			left = harbourNodes[i]
		} else if harbourNodes[i].IsHarbour && right == nil {
			right = harbourNodes[i]
			left.Next = right
			right.Last = left
			for j := left.Number + 1; j <= right.Number-1; j++ {
				l[j] = &Node{Last: left, Next: right, Number: j}
			}
			left = right
			right = nil
		}
	}
	f := func(a, b int) int {
		if l[a].IsHarbour {
			a++
		}
		if l[b].IsHarbour {
			b--
		}

		return ((b-a)*(b-a+1)/2 + (b-a+1)*(l[b].Next.Number-b)) * l[b].Last.Value
	}
	for i := 0; i < q; i++ {
		t, a, b := r.NextInt(), r.NextInt(), r.NextInt()
		if t == 1 {
			l[a].Value = b
			l[a].IsHarbour = true
			for j := l[a].Last.Number; j <= a-1; j++ {
				l[j].Next = l[a]
			}
			for j := a + 1; j <= l[a].Next.Number; j++ {
				l[j].Last = l[a]
			}
		}
		if t == 2 {
			ans := 0
			if l[a].IsHarbour {
				a++
			}
			if l[b].IsHarbour {
				b--
			}
			ll, rr := a, b
			for l[ll].Next.Number <= rr {
				ans += f(ll, l[ll].Next.Number)
				ll = l[ll].Next.Number
			}
			if ll <= rr {
				ans += f(ll, rr)
			}
			fmt.Println(ans)
		}
	}

}
