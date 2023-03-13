let func x = x + 1

let myx = func 13

// highlight and option + enter
let tuple = (95, 10)

let tupleFunc1 x y = (x + y, x * y)

let tupleFunc (x, y) = (x + y, x * y)

tupleFunc1 1 1

// let x, y = tuple |> tupleFunc
let x, y = tupleFunc tuple

let t = struct (1, 1)

open System

type MessageState =
    | Off
    | Active of WhenActive: DateTime
    | Idle of IdleDuration: TimeSpan
    | Recieved of Message: string * When: DateTime

let state = Active(DateTime.Now)

let state2 = Recieved("", DateTime.Now)



let safeDevide (x, y) = if y = 0.0 then None else Some(x / y)



let _array = [| 1..10 |]
let _list1 = [ 1..10 ]
let _seq = seq { 1..10 }
let _set = set { 1..10 }
let _map = Map.empty.Add(1, 1).Add(2, 2)

_array.[1] <- 5

let array1 = [| 1; 2; 3 |]
let array2 = [| 1..3 |]
let array3 = [| for i in 1..3 -> i |]
let array4 = Array.init 3 (fun id -> id + 1)
let array5 = Array.create 3 0
let array6 = Array.zeroCreate<int> 3

// linked list. data and pointer to the next element
let list1 = [ 1; 2; 3 ]
let list2 = [ 1..3 ]
let list3 = [ for i in 1..3 -> i ]
let list4 = List.init 3 (fun id -> id + 1)
let list5: list<int> = []
let list6 = List.empty<int>
let list7 = 0 :: list1 // :: cons operator. add 0 at the head position
let list8 = list1 @ [ 5 ]

let rec printTheList l =
    match l with
    | [] -> ()
    | head :: tail ->
        printfn "%i" head
        printTheList tail

printTheList list2

// is any object that implement IEnumerable
let seq1 = seq [| 1; 2; 3 |]
let seq2 = seq [| 1..3 |] // because array implements IEnumerable, we can create array and use it as seq
let seq3 = seq [ 1; 2; 3 ] // because list implements IEnumerable, we can create list and use it as seq
let seq4 = seq [ 1..3 ]
let seq5 = seq { 1..3 }
seq5 |> Seq.take 1
seq5
let seq6 = seq { for i in 1..3 -> i }
let seq7 = Seq.init 3 (fun id -> id + 1)
let seq8 = Seq.initInfinite (fun id -> id + 1)
seq8 |> Seq.take 1
seq8

// a set prevents duplites
let set1 = set [ 1; 2; 3; 4 ]
let set2 = set1.Add 8 // created a new set

set1.IsProperSubsetOf set1

let map1 =
    Map.empty.Add(1, "1").Add(2, "2").Add(3, "3")

map1.[2]
