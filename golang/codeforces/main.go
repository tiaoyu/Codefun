package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

type R struct {
	sc        *bufio.Reader
	split     []string
	index     int
	separator string
}

func (in *R) GetLine() string {
	line, err := in.sc.ReadString('\n')
	if err != nil {
		fmt.Println("error line:", line, " err: ", err)
	}
	in.split = []string{}
	in.index = 0
	return line
}
func (in *R) load() {
	if len(in.split) <= in.index {
		in.split = strings.Split(in.GetLine(), in.separator)
		in.index = 0
	}
}

func (in *R) NextInt() int {
	in.load()
	val, _ := strconv.Atoi(strings.TrimSpace(in.split[in.index]))
	in.index++
	return val
}

func (in *R) NextInt64() int64 {
	in.load()
	val, _ := strconv.ParseInt(strings.TrimSpace(in.split[in.index]), 10, 64)
	in.index++
	return val
}
func NewR(r *bufio.Reader) *R {
	return &R{
		sc:        r,
		split:     []string{},
		index:     0,
		separator: " ",
	}
}
func (in *R) NextString() string {
	in.load()
	val := strings.TrimSpace(in.split[in.index])
	in.index++
	return val
}

func (in *R) GetSlice(n int) []int {
	l := make([]int, n)
	for i := 0; i < n; i++ {
		l[i] = in.NextInt()
	}
	return l
}
func main() {
	CF1937D()
}

func CF1937D() { // NO SUBMIT
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

// func CF1937A() {
// 	r := NewR(bufio.NewReader(os.Stdin))
// 	t := r.NextInt()
// 	for t > 0 {
// 		t--
// 	}
// }
