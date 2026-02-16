import { useEffect, useState } from 'react';
import api from '../api/axiosInstance';
import ProductCard from '../components/ProductCard';
import Navbar from '../components/Navbar';

const ProductList = () => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await api.get('/products');
                setProducts(response.data);
            } catch (error) {
                console.error("Failed to fetch products", error);
            } finally {
                setLoading(false);
            }
        };

        fetchProducts();
    }, []);

    if (loading) return (
        <div className="flex justify-center items-center h-screen bg-passionBlack text-gold font-serif text-2xl animate-pulse tracking-widest uppercase">
            Invocando Elegancia...
        </div>
    );

    return (
        <div className="min-h-screen bg-passionBlack">
            <Navbar />
            <div className="max-w-7xl mx-auto py-16 px-4 sm:py-24 sm:px-6 lg:px-8">
                <div className="text-center mb-16 space-y-4">
                    <h2 className="text-4xl font-serif text-white sm:text-6xl tracking-[0.2em] uppercase">
                        La Colección
                    </h2>
                    <div className="w-24 h-px bg-gold mx-auto opacity-50"></div>
                    <p className="mt-6 text-softGray/60 max-w-2xl mx-auto font-sans font-light tracking-widest uppercase text-[10px]">
                        Selecciones curadas para la profunda exploración del placer.
                    </p>
                </div>

                <div className="grid grid-cols-1 gap-y-16 gap-x-8 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
                    {products.map((product) => (
                        <ProductCard key={product.id} product={product} />
                    ))}
                </div>
            </div>
        </div>
    );
};

export default ProductList;
