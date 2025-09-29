
public class FInc implements F {

    @Override
    public F apply(F f) {
        FInt i = (FInt) f;
        int newI = i.value + 1;
        return new FInt(newI);
    }

}
