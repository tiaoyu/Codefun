package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
)

func CF1931A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	latin := " abcdefghijklmnopqrstuvwxyz"
	for t > 0 {
		t--
		n := r.NextInt()
		ans := ""
		if n > 52 {
			ans = string(latin[n-52]) + "zz"
		} else if n > 27 {
			ans = "a" + string(latin[n-26-1]) + "z"
		} else {
			ans = "aa" + string(latin[n-2])
		}
		fmt.Println(ans)
	}
}
func CF1931B() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		l := make([]int, n)
		sum := 0
		for i := 0; i < n; i++ {
			l[i] = r.NextInt()
			sum += l[i]
		}
		avg := sum / n
		sum = 0
		flag := "YES"
		for i := 0; i < n; i++ {
			sum += l[i]
			if sum < avg*(i+1) {
				flag = "NO"
				break
			}
		}

		fmt.Println(flag)
	}
}
func CF1931C() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		l := make([]int, n)
		for i := 0; i < n; i++ {
			l[i] = r.NextInt()
		}

		maxLeft := 1
		for i := 1; i < n; i++ {
			if l[i] != l[i-1] {
				break
			} else {
				maxLeft++
			}
		}
		maxRight := 1
		for i := n - 1; i > 0; i-- {
			if l[i-1] != l[i] {
				break
			} else {
				maxRight++
			}
		}

		if l[0] == l[n-1] {
			if maxLeft == n {
				fmt.Println(0)
			} else {
				fmt.Println(n - maxLeft - maxRight)
			}
		} else {
			if maxLeft > maxRight {
				fmt.Println(n - maxLeft)
			} else {
				fmt.Println(n - maxRight)
			}
		}
	}
}
func CF1931D() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n, x, y := r.NextInt(), r.NextInt(), r.NextInt()
		lx, ly := make([]int, n), make([]int, n)
		m := make(map[struct{ a, b int }]int, n)
		ans := 0
		for i := 0; i < n; i++ {
			tmp := r.NextInt()
			lx[i] = tmp % x
			ly[i] = tmp % y
			ans += m[struct {
				a int
				b int
			}{(x - lx[i]%x) % x, ly[i] % y}]
			m[struct{ a, b int }{lx[i], ly[i]}]++
		}

		fmt.Println(ans)
	}
}
func CF1931E() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n, m := r.NextInt(), r.NextInt()
		mm := make([]struct{ cnt, zero int }, n)
		for i := 0; i < n; i++ {
			tmp := r.NextString()
			zero := 0
			for j := len(tmp) - 1; j >= 0; j-- {
				if tmp[j] == '0' {
					zero++
				} else {
					break
				}
			}
			mm = append(mm, struct {
				cnt  int
				zero int
			}{len(tmp), zero})
		}

		sort.Slice(mm, func(i, j int) bool {
			return mm[i].zero > mm[j].zero
		})
		cnt := 0
		for i, k := range mm {
			if i&1 == 0 {
				cnt += k.cnt - k.zero
			} else {
				cnt += k.cnt
			}
		}
		if cnt >= m+1 {
			fmt.Println("Sasha")
		} else {
			fmt.Println("Anna")
		}
	}
}

// 图：
// 使用邻接表存图，从入度为零的节点开始bfs，每次bfs的时候，将节点的所有邻居入度减一，如果减完后，邻居入度为零，则将节点入队
// 使用 map[int]map[int]struct{} 替代 map[int][]int 来存图，减少重复边
// 其中 vw 为每个节点的入度数量，q 为入度为零的节点的数组
func CF1931F() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n, k := r.NextInt(), r.NextInt()

		a := make(map[int]map[int]struct{}, k)

		for i := 0; i < k; i++ {
			var last int
			for j := 0; j < n; j++ {
				if j > 1 {
					if _, ok := a[last]; !ok {
						a[last] = make(map[int]struct{})
					}
					tmp := r.NextInt()
					a[last][tmp] = struct{}{}
					last = tmp
				} else {
					last = r.NextInt()
				}
			}
		}

		vw := make(map[int]int, n)
		for k, v := range a {
			vw[k] += 0
			for i := range v {
				vw[i]++
			}
		}

		q := make([]int, 0)
		for k, v := range vw {
			if v == 0 {
				q = append(q, k)
			}
		}
		inx := 0
		for len(q) > 0 {
			k := q[0]
			q = q[1:]
			inx++
			for v := range a[k] {
				vw[v]--
				if vw[v] == 0 {
					q = append(q, v)
				}
			}
		}

		flag := true
		for _, v := range vw {
			if v > 0 {
				flag = false
				break
			}
		}
		if !flag {
			fmt.Println("NO")
		} else {
			fmt.Println("YES")
		}
	}
}
