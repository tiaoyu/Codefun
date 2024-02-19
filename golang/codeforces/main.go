package main

import (
	"bufio"
	"fmt"
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
	CF1931F()
}
