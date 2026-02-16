import { useState, useEffect } from 'react';
import api from '../api/axiosInstance';
import Navbar from '../components/Navbar';
import toast from 'react-hot-toast';

const AdminPanel = () => {
    const [products, setProducts] = useState([]);
    const [isEditing, setIsEditing] = useState(false);
    const [editId, setEditId] = useState(null);
    const [newProduct, setNewProduct] = useState({
        name: '',
        description: '',
        price: '',
        stock: '',
        category: '',
        imageUrl: ''
    });

    useEffect(() => {
        fetchProducts();
    }, []);

    const fetchProducts = async () => {
        try {
            const response = await api.get('/products');
            setProducts(response.data);
        } catch (error) {
            console.error("Error fetching products", error);
        }
    };

    const handleChange = (e) => {
        setNewProduct({ ...newProduct, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (isEditing) {
                await api.put(`/products/${editId}`, { ...newProduct, id: editId });
                toast.success("Pieza actualizada en el archivo");
            } else {
                await api.post('/products', newProduct);
                toast.success("Nueva pieza añadida a la colección");
            }
            cancelEdit();
            fetchProducts();
        } catch (error) {
            console.error("Error saving product", error);
            if (error.response?.status === 403) {
                toast.error("Prohibido: Tu sesión actual no tiene autorización administrativa.");
            } else {
                toast.error("Error interno durante la actualización del archivo");
            }
        }
    };

    const handleEdit = (product) => {
        setIsEditing(true);
        setEditId(product.id);
        setNewProduct({
            name: product.name,
            description: product.description,
            price: product.price,
            stock: product.stock,
            category: product.category,
            imageUrl: product.imageUrl
        });
        window.scrollTo({ top: 0, behavior: 'smooth' });
    };

    const cancelEdit = () => {
        setIsEditing(false);
        setEditId(null);
        setNewProduct({ name: '', description: '', price: '', stock: '', category: '', imageUrl: '' });
    };

    const handleDelete = async (id) => {
        if (window.confirm("¿Estás seguro de que quieres eliminar esta pieza del archivo?")) {
            try {
                const response = await api.delete(`/products/${id}`);
                // Check if response indicates success even if not 200 OK (though delete usually is)
                toast.success("Pieza eliminada del archivo");
                fetchProducts();
            } catch (error) {
                console.error("Error deleting product", error);
                if (error.response?.status === 403) {
                    toast.error("Prohibido: Acción restringida a niveles de autorización superiores.");
                } else {
                    toast.error("Fallo al eliminar la pieza.");
                }
            }
        }
    };

    return (
        <div className="min-h-screen bg-passionBlack">
            <Navbar />
            <div className="max-w-7xl mx-auto py-10 px-4 sm:px-6 lg:px-8">
                <div className="flex justify-between items-center mb-12">
                    <h1 className="text-4xl font-serif text-white uppercase tracking-[0.3em]">Consola de Curación</h1>
                    <div className="h-px flex-grow bg-gold/20 mx-8"></div>
                    <span className="text-gold font-sans text-[10px] tracking-widest uppercase opacity-60">Acceso Nivel Admin</span>
                </div>

                {/* Form Section */}
                <div className="bg-[#1A1A1A] p-10 border border-gold/10 shadow-2xl mb-16 relative overflow-hidden rounded-3xl">
                    <div className="absolute top-0 left-0 w-1 h-full bg-passionRed"></div>
                    <h2 className="text-2xl font-serif text-white mb-8 uppercase tracking-widest flex items-center">
                        {isEditing ? "Modificar Existencia" : "Manifestar Nueva Pieza"}
                        {isEditing && <span className="ml-4 text-[10px] text-gold animate-pulse">MODO EDICIÓN</span>}
                    </h2>

                    <form onSubmit={handleSubmit} className="grid grid-cols-1 md:grid-cols-2 gap-8">
                        <div className="space-y-2">
                            <label className="text-[10px] text-softGray/40 uppercase tracking-widest ml-1">Designación</label>
                            <input type="text" name="name" placeholder="Nombre de la pieza" value={newProduct.name} onChange={handleChange} className="w-full bg-black border border-gold/20 p-4 rounded-xl text-white focus:border-gold outline-none transition-all" required />
                        </div>
                        <div className="space-y-2">
                            <label className="text-[10px] text-softGray/40 uppercase tracking-widest ml-1">Clasificación</label>
                            <input type="text" name="category" placeholder="Categoría" value={newProduct.category} onChange={handleChange} className="w-full bg-black border border-gold/20 p-4 rounded-xl text-white focus:border-gold outline-none transition-all" />
                        </div>
                        <div className="space-y-2">
                            <label className="text-[10px] text-softGray/40 uppercase tracking-widest ml-1">Valor ($)</label>
                            <input type="number" name="price" placeholder="0.00" value={newProduct.price} onChange={handleChange} className="w-full bg-black border border-gold/20 p-4 rounded-xl text-white focus:border-gold outline-none transition-all" required />
                        </div>
                        <div className="space-y-2">
                            <label className="text-[10px] text-softGray/40 uppercase tracking-widest ml-1">Disponibilidad</label>
                            <input type="number" name="stock" placeholder="Cantidad" value={newProduct.stock} onChange={handleChange} className="w-full bg-black border border-gold/20 p-4 rounded-xl text-white focus:border-gold outline-none transition-all" required />
                        </div>
                        <div className="md:col-span-2 space-y-2">
                            <label className="text-[10px] text-softGray/40 uppercase tracking-widest ml-1">URL del Activo Visual</label>
                            <input type="text" name="imageUrl" placeholder="https://..." value={newProduct.imageUrl} onChange={handleChange} className="w-full bg-black border border-gold/20 p-4 rounded-xl text-white focus:border-gold outline-none transition-all" />
                        </div>
                        <div className="md:col-span-2 space-y-2">
                            <label className="text-[10px] text-softGray/40 uppercase tracking-widest ml-1">La Narrativa (Descripción)</label>
                            <textarea name="description" placeholder="Describe el alma de esta pieza..." value={newProduct.description} onChange={handleChange} className="w-full bg-black border border-gold/20 p-4 rounded-xl text-white focus:border-gold outline-none transition-all h-32 resize-none" />
                        </div>

                        <div className="md:col-span-2 flex gap-4 mt-4">
                            <button type="submit" className="flex-grow bg-passionRed text-white py-5 px-8 rounded-xl hover:bg-passionRed/80 transition uppercase tracking-widest text-xs font-bold border border-gold/10 shadow-lg hover:shadow-passionRed/20">
                                {isEditing ? "Actualizar Archivo" : "Añadir a Colección Privada"}
                            </button>
                            {isEditing && (
                                <button type="button" onClick={cancelEdit} className="bg-transparent text-white py-5 px-8 rounded-xl hover:bg-white/5 transition uppercase tracking-widest text-xs font-bold border border-white/20">
                                    Cancelar
                                </button>
                            )}
                        </div>
                    </form>
                </div>

                {/* Table Section */}
                <div className="bg-[#1A1A1A] p-10 border border-gold/10 shadow-2xl rounded-3xl overflow-hidden">
                    <h2 className="text-xl font-serif text-white mb-8 uppercase tracking-widest">Inventario Activo</h2>
                    <div className="overflow-x-auto">
                        <table className="min-w-full divide-y divide-gold/10">
                            <thead>
                                <tr className="bg-black/40">
                                    <th className="px-6 py-5 text-left text-xs font-bold text-gold uppercase tracking-[0.2em]">Pieza</th>
                                    <th className="px-6 py-5 text-left text-xs font-bold text-gold uppercase tracking-[0.2em]">Valor</th>
                                    <th className="px-6 py-5 text-left text-xs font-bold text-gold uppercase tracking-[0.2em]">Stock</th>
                                    <th className="px-6 py-5 text-right text-xs font-bold text-gold uppercase tracking-[0.2em]">Acciones</th>
                                </tr>
                            </thead>
                            <tbody className="divide-y divide-gold/10">
                                {products.map((product) => (
                                    <tr key={product.id} className="hover:bg-gold/5 transition-colors group">
                                        <td className="px-6 py-6 whitespace-nowrap">
                                            <div className="flex items-center">
                                                <div className="h-10 w-10 bg-black border border-gold/10 flex-shrink-0 rounded-lg overflow-hidden">
                                                    {product.imageUrl && <img src={product.imageUrl} alt="" className="h-full w-full object-cover opacity-60 group-hover:opacity-100 transition" />}
                                                </div>
                                                <div className="ml-4">
                                                    <div className="text-sm font-serif text-white uppercase tracking-wider">{product.name}</div>
                                                    <div className="text-[10px] text-softGray/40 uppercase">{product.category}</div>
                                                </div>
                                            </div>
                                        </td>
                                        <td className="px-6 py-6 whitespace-nowrap text-sm text-gold tracking-widest">${product.price}</td>
                                        <td className="px-6 py-6 whitespace-nowrap text-sm text-softGray/60 flex items-center gap-2">
                                            {product.stock}
                                            <span className={`w-1.5 h-1.5 rounded-full ${product.stock > 0 ? 'bg-green-500/50' : 'bg-passionRed animate-pulse'}`}></span>
                                        </td>
                                        <td className="px-6 py-6 whitespace-nowrap text-right text-xs font-medium space-x-6">
                                            <button onClick={() => handleEdit(product)} className="text-white hover:text-gold transition-colors uppercase tracking-widest font-bold">Editar</button>
                                            <button onClick={() => handleDelete(product.id)} className="text-passionRed/60 hover:text-passionRed transition-colors uppercase tracking-widest font-bold">Eliminar</button>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AdminPanel;
