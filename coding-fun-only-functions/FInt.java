
public class FInt implements F {

    public final int value;

    public FInt(int value) {
        this.value = value;
    }

    @Override
    public F apply(F f) {
        throw new AssertionError();
    }

}
