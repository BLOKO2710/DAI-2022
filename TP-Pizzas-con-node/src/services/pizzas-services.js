import config from '../../dbconfig.js'
import sql from 'mssql'
import Pizza from '../models/pizza.js';



class PizzaService {
    getAll = async () => {
        try {
            let pool   = await sql.connect(config);
            let result = await pool.request()
                                .query('SELECT * FROM PIZZAS');
            return result.recordsets
        } catch (error) {
            console.log(error);
        }
    }
    getById = async (id) => {
        let returnEntity = null;
        console.log('Estoy en: PizzaService.GetById(id)')
        try {
            let pool   = await sql.connect(config);
            let result = await pool.request()
                                .input('pId', sql.Int, id)
                                .query('SELECT * FROM Pizzas WHERE id = @pId');
            returnEntity = result.recordsets[0][0];                    
        } catch (error) {
            console.log(error);
        }
        return returnEntity;
    }

    insert = async (pizza) => {
        try {
            console.log(pizza);
            let pool   = await sql.connect(config);
            let result = await pool.request()
                                    .input("Nombre", sql.VarChar, pizza.Nombre)
                                    .input("LibreGluten", sql.Bit, pizza.LibreGluten)
                                    .input("Importe", sql.Float, pizza.Importe)
                                    .input("Descripcion", sql.VarChar, pizza.Descripcion)
                                    .query("INSERT INTO Pizzas (Nombre, LibreGluten, Importe, Descripcion) VALUES (@Nombre, @LibreGluten, @Importe, @Descripcion)");
    return result.rowsAffected;
        } catch (error) {
            console.log(error);
        }
    }
    update = async (pizza,id) => {
        let rowsAffected = 0;
        try {
            let pool   = await sql.connect(config);
            let result = await pool.request()
                .input("id", sql.Int, id)
                .input("nombre", sql.NChar, pizza.Nombre)
                .input("libreGluten", sql.Bit, pizza.LibreGluten)
                .input("importe", sql.Float, pizza.Importe)
                .input("descripcion", sql.NChar, pizza.Descripcion)
                .query("UPDATE Pizzas SET nombre = @nombre, libreGluten = @libreGluten, importe = @importe, descripcion = @descripcion WHERE id = @id");
                rowsAffected = result.rowsAffected;
        } catch (error) {
            console.log(error);
        }
        return rowsAffected
    }
    deleteById = async (id) => {
        let retunrEntity = 0;
        console.log('Estoy en: PizzaService.deleteById(id)')
    try {
        let pool = await sql.connect(config);
        let result = await pool.request()
                            .input('pId', sql.Int, id)
                            .query('DELETE FROM Pizzas WHERE id = @pId');
        retunrEntity = result.recordsets;              
        console.log(result);      
    } catch (error) {
        console.log(error);
    }
    return retunrEntity;
    }
}
export default PizzaService;