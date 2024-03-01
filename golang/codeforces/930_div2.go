package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func CF1937A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		cnt := 0
		for n > 0 {
			n >>= 1
			cnt++
		}
		fmt.Println(1 << (cnt - 1))
	}
}
func CF1937B() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		grid := make([]string, 2)
		grid[0] = r.NextString()
		grid[1] = r.NextString()

		ans := strings.Builder{}
		ans.WriteString(string(grid[0][0]))
		min := 1
		finish := true
		for i := 1; i < n; i++ {
			if grid[0][i] == grid[1][i-1] {
				ans.WriteString(string(grid[0][i]))
				min++
			} else if grid[0][i] < grid[1][i-1] {
				ans.WriteString(string(grid[0][i]))
				min = 1
			} else {
				ans.WriteString(string(grid[1][i-1]) + string(grid[1][i:]))
				finish = false
				break
			}
		}
		if finish {
			ans.WriteString(string(grid[1][n-1]))
		}
		fmt.Println(ans.String())
		fmt.Println(min)
	}
}
func CF1937D() { // TLE
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	left := func(l, r *int, pp []uint8) bool {
		if pp[*l] == '>' {
			*l = (*l) - 1
			return false
		}
		*l = (*l) - 1
		return true
	}
	right := func(l, r *int, pp []uint8) bool {
		if pp[*r] == '<' {
			*r = (*r) + 1
			return true
		}
		*r = (*r) + 1
		return false
	}
	for t > 0 {
		t--
		n := r.NextInt()
		path := r.NextString()
		p := make([]uint8, n)
		for i, v := range path {
			p[i] = uint8(v)
		}

		for i := 0; i < n; i++ {
			l, r := i, i
			var f func(*int, *int, []uint8) bool
			if p[i] == '<' {
				f = left
			} else {
				f = right
			}
			cnt := 1
			cur := f(&l, &r, p)
			if cur {
				f = left
				r++
			} else {
				f = right
				l--
			}
			if (cur && l < 0) || (!cur && r >= n) {
			} else {
				for {
					tmp := f(&l, &r, p)
					if tmp {
						f = left
					} else {
						f = right
					}
					if tmp != cur {
						cnt += (r - l - 1)
						cur = tmp
					} else {
						cnt++
					}
					if (tmp && l < 0) || (!tmp && r >= n) {
						break
					}
				}
			}
			if i == 0 {
				fmt.Print(cnt)
			} else {
				fmt.Print(" ", cnt)
			}
		}
		fmt.Println()
	}
}
