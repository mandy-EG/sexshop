import { useContext } from 'react';
import { Link } from 'react-router-dom';
import { useAuth } from '../context/AuthContext'; // Fix import path
import { useCart } from '../context/CartContext';
import { ShoppingBag, User, LogOut } from 'lucide-react';

const Navbar = () => {
    const { user, logout } = useAuth();
    const { cartCount } = useCart();

    return (
        <nav className="bg-passionBlack/90 backdrop-blur-md border-b border-gold/20 sticky top-0 z-50 transition-all duration-300">
            <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
                <div className="flex justify-between items-center h-16">
                    <div className="flex-shrink-0 flex items-center">
                        <Link to="/" className="text-2xl font-serif text-gold tracking-widest uppercase">
                            Velvet & Ivory
                        </Link>
                    </div>

                    <div className="hidden sm:flex sm:items-center sm:space-x-8">
                        <Link to="/" className="text-softGray hover:text-passionRed transition-colors duration-200 uppercase text-xs tracking-widest font-sans">
                            Colección
                        </Link>
                        <Link to="/about" className="text-softGray hover:text-passionRed transition-colors duration-200 uppercase text-xs tracking-widest font-sans">
                            Nuestra Historia
                        </Link>
                    </div>

                    <div className="flex items-center space-x-6">
                        {user ? (
                            <>
                                <span className="text-xs text-gold hidden md:block uppercase tracking-wider">Hola, {user.email.split('@')[0]}</span>
                                {user.roles && user.roles.includes('Admin') && (
                                    <Link to="/admin" className="text-softGray hover:text-gold text-xs uppercase tracking-widest font-sans">
                                        Panel
                                    </Link>
                                )}
                                <button onClick={logout} className="text-softGray hover:text-passionRed transition-colors">
                                    <LogOut size={18} />
                                </button>
                            </>
                        ) : (
                            <Link to="/login" className="text-softGray hover:text-passionRed transition-colors">
                                <User size={18} />
                            </Link>
                        )}
                        <Link to="/cart" className="text-softGray hover:text-passionRed transition-colors relative">
                            <ShoppingBag size={18} />
                            {cartCount > 0 && (
                                <span className="absolute -top-1.5 -right-1.5 bg-passionRed text-white text-[10px] font-bold rounded-full h-4 w-4 flex items-center justify-center animate-pulse border border-passionBlack">
                                    {cartCount}
                                </span>
                            )}
                        </Link>
                    </div>
                </div>
            </div>
        </nav>
    );
};

export default Navbar;
