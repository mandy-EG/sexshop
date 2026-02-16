import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import AuthProvider, { useAuth } from './context/AuthContext';
import ProductList from './pages/ProductList';
import AdminPanel from './pages/AdminPanel';
import About from './pages/About';
import Cart from './pages/Cart';
import { useContext } from 'react';

// Login Component (Inline for simplicity, ideally separate)
import { useState } from 'react';
import Navbar from './components/Navbar';
import toast from 'react-hot-toast';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { login } = useAuth();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await login(email, password);
            window.location.href = '/'; // Simple redirect
        } catch (error) {
            toast.error('Fallo al iniciar sesión. Verifica tus credenciales.');
        }
    };

    return (
        <div className="min-h-screen bg-passionBlack flex flex-col">
            <Navbar />
            <div className="flex-grow flex items-center justify-center p-4">
                <form onSubmit={handleSubmit} className="bg-[#1A1A1A] p-10 rounded-3xl shadow-2xl w-full max-w-md border border-gold/10">
                    <h2 className="text-3xl font-serif text-white mb-8 text-center uppercase tracking-[0.2em]">Acceso Privado</h2>
                    <div className="space-y-6">
                        <div className="relative">
                            <input type="email" placeholder="Identidad (Email)" value={email} onChange={(e) => setEmail(e.target.value)} className="w-full bg-black border border-gold/20 p-4 rounded-xl text-white focus:border-gold outline-none tracking-widest text-sm" required />
                        </div>
                        <div className="relative">
                            <input type="password" placeholder="Contraseña" value={password} onChange={(e) => setPassword(e.target.value)} className="w-full bg-black border border-gold/20 p-4 rounded-xl text-white focus:border-gold outline-none tracking-widest text-sm" required />
                        </div>
                    </div>
                    <button type="submit" className="w-full bg-passionRed text-white py-4 rounded-xl hover:bg-passionRed/80 transition-all duration-300 uppercase tracking-[0.3em] text-xs font-bold border border-gold/10 mt-10 shadow-lg hover:shadow-passionRed/20">
                        Entrar
                    </button>
                    <p className="text-[10px] text-softGray/40 mt-8 text-center uppercase tracking-widest italic">
                        Autenticación segura y discreta
                    </p>
                </form>
            </div>
        </div>
    );
};

const PrivateRoute = ({ children, roles }) => {
    const { user, loading } = useAuth();

    if (loading) return <div>Loading...</div>;

    if (!user) {
        return <Navigate to="/login" />;
    }

    if (roles && !roles.some(r => user.roles.includes(r))) {
        return <Navigate to="/" />;
    }

    return children;
};

import { CartProvider } from './context/CartContext';

import { Toaster } from 'react-hot-toast';

function App() {
    return (
        <Router future={{ v7_startTransition: true, v7_relativeSplatPath: true }}>
            <AuthProvider>
                <CartProvider>
                    <Toaster
                        position="top-center"
                        toastOptions={{
                            style: {
                                background: '#1A1A1A',
                                color: '#fff',
                                border: '1px solid rgba(212, 175, 55, 0.3)',
                                borderRadius: '12px',
                                fontFamily: 'serif',
                            },
                            success: {
                                iconTheme: {
                                    primary: '#D4AF37',
                                    secondary: '#1A1A1A',
                                },
                            },
                        }}
                    />
                    <Routes>
                        <Route path="/" element={<ProductList />} />
                        <Route path="/about" element={<About />} />
                        <Route path="/cart" element={<Cart />} />
                        <Route path="/login" element={<Login />} />
                        <Route path="/admin" element={
                            <PrivateRoute roles={['Admin']}>
                                <AdminPanel />
                            </PrivateRoute>
                        } />
                    </Routes>
                </CartProvider>
            </AuthProvider>
        </Router>
    );
}

export default App;
