import { useCart } from '../context/CartContext';

const ProductCard = ({ product }) => {
    const { addToCart } = useCart();

    return (
        <div className="group relative bg-[#1A1A1A] border border-gold/10 rounded-3xl overflow-hidden hover:border-gold/30 transition-all duration-500 shadow-2xl hover:shadow-gold/5 hover:-translate-y-1">
            <div className="aspect-h-1 aspect-w-1 w-full overflow-hidden bg-black lg:aspect-none h-96">
                <img
                    src={product.imageUrl || "https://via.placeholder.com/400x500?text=Velvet+Ivory"}
                    alt={product.name}
                    className="h-full w-full object-cover object-center lg:h-full lg:w-full group-hover:scale-110 transition-transform duration-700 opacity-80 group-hover:opacity-100"
                />
            </div>
            <div className="mt-6 flex justify-between px-6 pb-4">
                <div>
                    <h3 className="text-xl font-serif text-white tracking-wide">
                        <span aria-hidden="true" className="absolute inset-0 pointer-events-none" />
                        {product.name}
                    </h3>
                    <p className="mt-2 text-xs uppercase tracking-widest text-gold/60">{product.category}</p>
                </div>
                <p className="text-xl font-sans font-light text-gold">${product.price}</p>
            </div>
            <button
                onClick={() => addToCart(product)}
                className="w-full bg-passionRed text-white py-4 hover:bg-passionRed/80 transition-all duration-300 font-sans tracking-widest uppercase text-xs font-bold relative z-10 border-t border-gold/20"
            >
                Añadir a la Colección
            </button>
        </div>
    );
};

export default ProductCard;
