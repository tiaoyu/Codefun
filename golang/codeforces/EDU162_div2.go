package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
)

func CF1923A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		zero := 0
		l := make([]int, n)
		for i := 0; i < n; i++ {
			tmp := r.NextInt()
			l[i] = tmp
			if tmp == 0 {
				zero++
			}
		}
		for _, v := range l {
			if v == 1 {
				break
			}
			if v == 0 {
				zero--
			}
		}
		for i := len(l) - 1; i >= 0; i-- {
			if l[i] == 1 {
				break
			}
			if l[i] == 0 {
				zero--
			}
		}
		fmt.Println(zero)
	}
}
func CF1923B() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n, k := r.NextInt(), r.NextInt()
		health := make([]int, n)
		for i := 0; i < n; i++ {
			health[i] = r.NextInt()
		}
		sumHealth := make(map[int]int)
		for i := 0; i < n; i++ {
			tmp := r.NextInt()
			if tmp < 0 {
				tmp = -tmp
			}
			sumHealth[tmp] += health[i]
		}
		var pos []int
		for k := range sumHealth {
			pos = append(pos, k)
		}
		sort.Slice(pos, func(i, j int) bool {
			return pos[i] < pos[j]
		})

		restBullet := 0
		delta := 0
		success := true
		for _, p := range pos {
			attack := (p-delta)*k + restBullet
			heal := sumHealth[p]
			if attack >= heal {
				restBullet = (attack - heal)
			} else {
				success = false
			}
			delta = p
		}
		if success {
			fmt.Println("YES")
		} else {
			fmt.Println("NO")
		}
	}
}
func CF1923C() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n, q := r.NextInt(), r.NextInt()
		sum, one := make([]int, n+1), make([]int, n+1)
		sum[0] = 0

		for i := 1; i <= n; i++ {
			tmp := r.NextInt()
			if tmp == 1 {
				one[i] = one[i-1] + tmp
			} else {
				one[i] = one[i-1]
			}
			sum[i] = sum[i-1] + tmp
		}

		for i := 0; i < q; i++ {
			low, high := r.NextInt(), r.NextInt()
			if low == high {
				fmt.Println("NO")
				continue
			}
			s := sum[high] - sum[low-1]
			o := one[high] - one[low-1] + (high - low + 1)
			if s >= o {
				fmt.Println("YES")
			} else {
				fmt.Println("NO")
			}

		}
	}
}

func CF1923D() { //TLE
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		l, sum := make([]int, n), make([]int, n+1)
		for i := 1; i <= n; i++ {
			l[i-1] = r.NextInt()
			sum[i] += sum[i-1]
		}
		lr := func(left, right, curV int) (int, bool) {
			if left > right {
				return -1, false
			}
			cnt := 1
			s := 0
			tmp := 0
			flag := false
			for j := left; j <= right; j++ {
				if l[j] != l[j-1] {
					s = s + tmp + l[j]
					tmp = 0
					if s > curV {
						flag = true
						break
					}
				} else {
					if s > l[j] {
						s = s + tmp + l[j]
						tmp = 0
						if s > curV {
							flag = true
							break
						}
					} else {
						tmp += l[j]
					}
				}
				cnt++
			}
			if flag {
				return cnt, true
			} else {
				return -1, true
			}
		}
		rl := func(left, right, curV int) (int, bool) {
			ok := false
			if left > right {
				return -1, ok
			}
			cnt := 1
			s := 0
			tmp := 0
			flag := false
			for j := right; j >= left; j-- {
				if l[j] != l[j+1] {
					s = s + tmp + l[j]
					tmp = 0
					if s > curV {
						flag = true
						break
					}
				} else {
					if s > l[j] {
						s = s + tmp + l[j]
						tmp = 0
						if s > curV {
							flag = true
							break
						}
					} else {
						tmp += l[j]
					}
				}
				cnt++
			}
			if flag {
				return cnt, true
			} else {
				return -1, true
			}
		}
		ans := make([]int, n)

		for i, v := range l {
			a, ok1 := rl(0, i-1, v)
			b, ok2 := lr(i+1, len(l)-1, v)

			if ok1 && ok2 {
				if a == -1 {
					ans[i] = b
				} else if b == -1 {
					ans[i] = a
				} else {
					if a < b {
						ans[i] = a
					} else {
						ans[i] = b
					}
				}
			} else if ok1 {
				ans[i] = a
			} else if ok2 {
				ans[i] = b
			} else {
				ans[i] = -1
			}
		}

		fmt.Print(ans[0])
		for i := 1; i < n; i++ {
			fmt.Print(" ", ans[i])
		}
		fmt.Println()
	}
}
