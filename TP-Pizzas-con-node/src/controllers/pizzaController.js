import { Router } from "express";
import PizzaService from "../services/pizzas-services.js";
const router = Router();
const pizzaService = new PizzaService();

router.get('', async (req,res) => {
    const pizza = await pizzaService.getAll();
    return res.status(200).json(pizza);
});

router.get('/:id', async(req,res)=>{
    const pizza = await pizzaService.getById(req.params.id);
    if (pizza == null) {
        console.log("No existe");
        return res.sendStatus(404);
    }
    return res.status(200).json(pizza);
});
router.post('', async (req,res) => {
    const pizza = await pizzaService.insert(req.body);
    return res.status(201).json(pizza);
});
router.put('/:id', async(req, res)=>{
    const pizza = await pizzaService.update(req.body,req.params.id);
    console.log(pizza);
    return res.status(200).json(pizza);    
})

router.delete('/:id', async(req,res)=>{
    const pizza = await pizzaService.deleteById(req.params.id)
    if (pizza == null) {
        console.log("No existe");
        return res.sendStatus(404);
    }
    return res.status(200).json(pizza);
})
export default router;