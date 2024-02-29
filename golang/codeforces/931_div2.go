package main

import (
	"bufio"
	"fmt"
	"os"
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

		ans := string(grid[0][0])
		min := 1
		finish := true
		for i := 1; i < n; i++ {
			if grid[0][i] == grid[1][i-1] {
				ans += string(grid[0][i])
				min++
			} else if grid[0][i] < grid[1][i-1] {
				ans += string(grid[0][i])
				min = 1
			} else {
				ans = ans + string(grid[1][i-1]) + string(grid[1][i:])
				finish = false
				break
			}
		}
		if finish {
			ans += string(grid[1][n-1])
		}
		fmt.Println(ans)
		fmt.Println(min)

	}
}
