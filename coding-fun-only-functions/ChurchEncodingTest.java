import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.function.BinaryOperator;
import java.util.function.Function;

import org.junit.jupiter.api.Test;

class ChurchEncodingTest {

    @Test
    void howCanWeHaveAFuncForTwoArguments() {
        BinaryOperator<Integer> add = (a, b) -> a + b;
        assertEquals((Integer) 3, add.apply(2, 1));

        Function<Integer, Function<Integer, Integer>> add2 = a -> b -> a + b;
        assertEquals((Integer) 3, add2.apply(2).apply(1));
    }

    F ZERO = f -> x -> x;
    F ONE = f -> x -> f.apply(x);

    @Test
    void howToTestThis() {
        assertEquals(0, convert(ZERO));
        assertEquals(1, convert(ONE));
    }

    private int convert(F n) {
        // x == int
        F x = new FInt(0);
        // f == inc
        F inc = new FInc();
        F result = n.apply(inc).apply(x);
        return ((FInt) result).value;
    }

    // F TWO = f -> x -> f.apply(f.apply(x));
    F INC = n -> f -> x -> n.apply(f).apply(f.apply(x));

    F TWO = INC.apply(ONE);

    @Test
    void moreNumbers() {
        assertEquals(2, convert(TWO));
        assertEquals(3, convert(INC.apply(TWO)));
    }

    F PAIR = left -> right -> indexer -> indexer.apply(left).apply(right);
    F INDEX_LEFT = left -> right -> left;
    F INDEX_RIGHT = left -> right -> right; // ZERO

    @Test
    void pair() {
        F p = PAIR.apply(ONE).apply(TWO);
        assertEquals(1, convert(p.apply(INDEX_LEFT)));
        assertEquals(2, convert(p.apply(INDEX_RIGHT)));
    }

    F DEC = n -> f -> x -> {
        F f2 = history -> {
            F oldX = history.apply(INDEX_LEFT);
            F newX = f.apply(oldX);
            F newPair = PAIR.apply(newX).apply(oldX);
            return newPair;
        };
        F x2 = PAIR.apply(x).apply(x);
        F resultPair = n.apply(f2).apply(x2);
        return resultPair.apply(INDEX_RIGHT);
    };

    @Test
    void decrement() {
        assertEquals(0, convert(DEC.apply(ONE)));
        assertEquals(1, convert(DEC.apply(TWO)));
        assertEquals(2, convert(DEC.apply(INC.apply(TWO))));
    }

    F ADD = a -> b -> f -> x -> a.apply(f).apply(b.apply(f).apply(x));

    @Test
    void add() {
        assertEquals(3, convert(ADD.apply(ONE).apply(TWO)));
        assertEquals(1, convert(ADD.apply(ONE).apply(ZERO)));
        assertEquals(0, convert(ADD.apply(ZERO).apply(ZERO)));
        assertEquals(5, convert(ADD.apply(TWO).apply(INC.apply(TWO))));
    }

}
