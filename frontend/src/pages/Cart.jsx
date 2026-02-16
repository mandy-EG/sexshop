import { useCart } from '../context/CartContext';
import Navbar from '../components/Navbar';
import { Trash2, Plus, Minus, ArrowLeft } from 'lucide-react';
import { useNavigate, Link } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import api from '../api/axiosInstance';
import toast from 'react-hot-toast';

const Cart = () => {
    const { cart, removeFromCart, addToCart, clearCart, cartCount } = useCart();
    const { user } = useAuth();
    const navigate = useNavigate();

    const total = cart.reduce((sum, item) => sum + item.price * item.quantity, 0);

    const handleCheckout = async () => {
        if (!user) {
            navigate('/login', { state: { from: '/cart' } });
            return;
        }

        try {
            // Transform cart items to match CreateOrderDto
            const orderItems = cart.map(item => ({
                productId: item.id,
                quantity: item.quantity
            }));

            await api.post('/orders', { items: orderItems });

            // Clear cart (we might want to move this to context)
            cart.forEach(item => removeFromCart(item.id));

            toast.success('¡Pedido realizado con éxito! Gracias por tu compra.');
            navigate('/'); // Or redirect to an orders page
        } catch (error) {
            console.error("Checkout failed", error);
            if (error.response && error.response.data) {
                console.error("Server response:", error.response.data);
                // If it's a simple string message
                if (typeof error.response.data === 'string') {
                    toast.error(`Error: ${error.response.data}`);
                } else if (error.response.data.title) {
                    // ASP.NET Core default validation error structure
                    toast.error(`Error: ${error.response.data.title}`);
                } else {
                    toast.error('El pago falló. Verifica la consola para más detalles.');
                }
            } else {
                toast.error('El pago falló. Por favor inténtalo de nuevo.');
            }
        }
    };

    if (cart.length === 0) {
        return (
            <div className="min-h-screen bg-passionBlack">
                <Navbar />
                <div className="max-w-7xl mx-auto py-24 px-4 text-center">
                    <h2 className="text-3xl font-serif text-white mb-6 tracking-widest uppercase">Tu selección está vacía</h2>
                    <p className="text-softGray mb-10 text-lg opacity-60">Deléitate con nuestras piezas curadas para encontrar tu próximo favorito.</p>
                    <Link to="/" className="inline-flex items-center text-gold hover:text-white transition-colors text-lg font-serif">
                        <ArrowLeft size={20} className="mr-2" /> Seguir Explorando
                    </Link>
                </div>
            </div>
        );
    }

    return (
        <div className="min-h-screen bg-passionBlack">
            <Navbar />
            <div className="max-w-7xl mx-auto py-16 px-4 sm:px-6 lg:px-8">
                <h1 className="text-4xl font-serif text-white mb-12 text-center tracking-[0.2em] uppercase">Selección Privada</h1>

                <div className="grid grid-cols-1 lg:grid-cols-3 gap-12">
                    <div className="lg:col-span-2 space-y-8">
                        {cart.map((item) => (
                            <div key={item.id} className="flex flex-col sm:flex-row bg-[#1A1A1A] p-6 rounded-2xl border border-gold/10 shadow-2xl transition-all hover:border-gold/30 group">
                                <div className="sm:w-32 sm:h-32 mb-4 sm:mb-0 flex-shrink-0 rounded-xl overflow-hidden">
                                    <img src={item.imageUrl} alt={item.name} className="w-full h-full object-cover grayscale hover:grayscale-0 transition-all duration-500" />
                                </div>
                                <div className="sm:ml-8 flex-grow">
                                    <div className="flex justify-between items-start">
                                        <div>
                                            <h3 className="text-xl font-serif text-white mb-1 tracking-wider">{item.name}</h3>
                                            <p className="text-xs uppercase tracking-widest text-gold/60 mb-4">{item.category}</p>
                                        </div>
                                        <p className="text-xl font-light text-gold">${(item.price * item.quantity).toFixed(2)}</p>
                                    </div>

                                    <div className="flex justify-between items-center mt-auto">
                                        <div className="flex items-center border border-gold/20 rounded-full px-3 py-1 bg-black">
                                            <button
                                                onClick={() => removeFromCart(item.id)}
                                                className="text-softGray hover:text-gold p-1"
                                            >
                                                <Minus size={16} />
                                            </button>
                                            <span className="mx-6 font-light text-white">{item.quantity}</span>
                                            <button
                                                onClick={() => addToCart(item)}
                                                className="text-softGray hover:text-gold p-1"
                                            >
                                                <Plus size={16} />
                                            </button>
                                        </div>
                                        <button
                                            onClick={() => removeFromCart(item.id)}
                                            className="text-passionRed/70 hover:text-passionRed transition-colors flex items-center text-xs uppercase tracking-widest font-sans"
                                        >
                                            <Trash2 size={16} className="mr-1" /> Eliminar
                                        </button>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>

                    <div className="bg-[#1A1A1A] p-8 rounded-3xl border border-gold/20 h-fit sticky top-24 shadow-2xl">
                        <h2 className="text-2xl font-serif text-gold mb-8 tracking-widest uppercase border-b border-gold/10 pb-4">Resumen</h2>
                        <div className="space-y-6 mb-8 text-sm uppercase tracking-widest font-sans font-light">
                            <div className="flex justify-between text-softGray/80">
                                <span>Subtotal ({cartCount} ítems)</span>
                                <span>${total.toFixed(2)}</span>
                            </div>
                            <div className="flex justify-between text-softGray/80">
                                <span>Envío</span>
                                <span className="text-gold italic">Cortesía</span>
                            </div>
                            <div className="border-t border-gold/10 pt-6 flex justify-between text-2xl font-serif text-white">
                                <span>Total</span>
                                <span className="text-gold">${total.toFixed(2)}</span>
                            </div>
                        </div>
                        <button
                            onClick={handleCheckout}
                            className="w-full bg-gold text-white py-5 hover:bg-gold/80 transition-all font-sans tracking-[0.3em] uppercase text-xs font-bold border border-gold/20 shadow-lg rounded-xl hover:shadow-gold/20"
                        >
                            Finalizar Solicitud
                        </button>
                        <button
                            onClick={clearCart}
                            className="w-full mt-4 bg-transparent text-softGray hover:text-passionRed py-3 transition-all font-sans tracking-[0.2em] uppercase text-[10px] font-bold border border-gold/10 hover:border-passionRed/30 rounded-xl"
                        >
                            Vaciar Carrito
                        </button>
                        <p className="text-center text-[10px] text-softGray/40 mt-8 font-sans italic tracking-widest">
                            Transacción encriptada exclusiva
                        </p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Cart;
