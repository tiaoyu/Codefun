package main

import (
	"bufio"
	"fmt"
	"os"
)

func CF1933A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	getOBS := func(a int) int {
		if a < 0 {
			return -a
		} else {
			return a
		}
	}
	for t > 0 {
		t--
		n := r.NextInt()
		ans := 0
		for i := 0; i < n; i++ {
			ans += getOBS(r.NextInt())
		}
		fmt.Println(ans)
	}
}
func CF1933B() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		m := make(map[int]int)
		sum := 0
		n := r.NextInt()
		for i := 0; i < n; i++ {
			tmp := r.NextInt()
			m[tmp%3]++
			sum += tmp
		}
		ans := sum % 3
		if ans == 0 {
			fmt.Println(0)
		} else if ans == 2 {
			fmt.Println(1)
		} else {
			if _, ok := m[ans]; ok {
				fmt.Println(1)
			} else {
				fmt.Println(2)
			}
		}
	}
}
func CF1933C() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()

	exactlyDiv2 := func(n, div, cnt int) (int, bool) {
		if n == 0 {
			return n, false
		}
		for cnt > 0 {
			cnt--
			if n%div == 0 {
				n /= div
				if n == 0 {
					return 0, false
				}
			} else {
				return 0, false
			}
		}
		return n, true
	}
	for t > 0 {
		t--
		a, b, l := r.NextInt(), r.NextInt(), r.NextInt()
		m := make(map[int]int)

		for i := 0; ; i++ {
			tmp, ok := exactlyDiv2(l, a, i)
			if !ok {
				break
			}
			for j := 0; ; j++ {
				tmp, ok := exactlyDiv2(tmp, b, j)
				if !ok {
					break
				} else {
					m[tmp]++
				}
			}
		}
		for i := 0; ; i++ {
			tmp, ok := exactlyDiv2(l, b, i)
			if !ok {
				break
			}
			for j := 0; ; j++ {
				tmp, ok := exactlyDiv2(tmp, a, j)
				if !ok {
					break
				} else {
					m[tmp]++
				}
			}
		}

		fmt.Println(len(m))

	}
}

func CF1933E() { //TLE
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	MIN := func(a, b int) (int, bool, bool) {
		bb := b
		if a < 0 {
			a = -a
		}
		if b < 0 {
			b = -b
		}
		if bb == 1 {
			return bb, true, true
		}
		if b < a {
			return b, true, false
		} else {
			return a, false, false
		}
	}
	for t > 0 {
		t--
		n := r.NextInt()
		l := make([]int, n)
		sum := make([]int, n+1)
		sum[0] = 0
		for i := 0; i < n; i++ {
			l[i] = r.NextInt()
			sum[i+1] += sum[i] + l[i]
		}
		q := r.NextInt()
		ans := make([]int, q)
		for i := 0; i < q; i++ {
			l, u := r.NextInt(), r.NextInt()
			min := 1000000000
			minR := l
			u++
			for right := l; right <= n; right++ {
				ss := sum[right] - sum[l-1]
				if ss > u {
					u-- 
				}
				tmp, ok, finished := MIN(min, u-ss)
				if finished {
					minR = right
					break
				}
				min = tmp
				if ok {
					minR = right
				}
				if ss > u+u+2 {
					break
				}
			}
			ans[i] = minR
		}

		fmt.Print(ans[0])
		for i := 1; i < q; i++ {
			fmt.Print(" ", ans[i])
		}
		fmt.Println()
	}
}
